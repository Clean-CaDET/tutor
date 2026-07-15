import sys
import re
from pathlib import Path

from common import db_cursor, to_json

OUTPUT_DIR = Path(__file__).parent / "data/conversations"

ATTEMPT_SQL = """
SELECT
    "Id",
    "ConceptElaborationTaskId",
    "LearnerId",
    "Status",
    "StartedAt",
    "CompletedAt",
    "FinalGrade",
    "TotalTargets",
    "MaxRounds"
FROM elaborations."ConversationAttempts"
WHERE "Id" = %s
"""

ROUNDS_SQL = """
SELECT
    cr."Order",
    cr."ElaborationContent",
    cr."SubmittedAt",
    cr."FeedbackContent",
    cr."Probes",
    re."Id" AS "RoundEvaluationId",
    re."Assessments"
FROM elaborations."ConversationRounds" cr
LEFT JOIN elaborations."RoundEvaluations" re
    ON re."ConversationRoundId" = cr."Id"
WHERE cr."ConversationAttemptId" = %s
ORDER BY cr."Order"
"""


def fetch_rounds(cursor, attempt_id):
    cursor.execute(ROUNDS_SQL, (attempt_id,))
    rounds = []
    for row in cursor.fetchall():
        evaluation = {"Assessments": row["Assessments"]} if row["RoundEvaluationId"] is not None else None
        rounds.append({
            "Order": row["Order"],
            "ElaborationContent": row["ElaborationContent"],
            "SubmittedAt": str(row["SubmittedAt"]),
            "FeedbackContent": row["FeedbackContent"],
            "Probes": row["Probes"],
            "Evaluation": evaluation,
        })
    return rounds


def fetch_attempt(cursor, attempt_id):
    cursor.execute(ATTEMPT_SQL, (attempt_id,))
    row = cursor.fetchone()
    if row is None:
        return None
    attempt = {
        "Id": row["Id"],
        "ConceptElaborationTaskId": row["ConceptElaborationTaskId"],
        "LearnerId": row["LearnerId"],
        "Status": row["Status"],
        "StartedAt": str(row["StartedAt"]),
        "CompletedAt": str(row["CompletedAt"]) if row["CompletedAt"] is not None else None,
        "FinalGrade": row["FinalGrade"],
        "TotalTargets": row["TotalTargets"],
        "MaxRounds": row["MaxRounds"],
    }
    attempt["Rounds"] = fetch_rounds(cursor, attempt_id)
    return attempt


def fetch_attempt_ids_for_task(cursor, task_id):
    cursor.execute(
        'SELECT "Id" FROM elaborations."ConversationAttempts"'
        ' WHERE "ConceptElaborationTaskId" = %s ORDER BY "Id"',
        (task_id,)
    )
    return [row["Id"] for row in cursor.fetchall()]


def resolve_ids(cursor, args):
    if len(args) == 1 and re.fullmatch(r'\d+\+', args[0]):
        min_id = int(args[0][:-1])
        cursor.execute(
            'SELECT DISTINCT "ConversationAttemptId" FROM elaborations."ConversationRounds"'
            ' WHERE "ConversationAttemptId" >= %s ORDER BY "ConversationAttemptId"',
            (min_id,)
        )
        return [row["ConversationAttemptId"] for row in cursor.fetchall()]
    return [int(arg) for arg in args]


def main():
    if len(sys.argv) < 2:
        print("Usage: python fetch_conversations.py <id1> [id2] ...")
        print("       python fetch_conversations.py <id>+   (fetch all attempts with Id >= id)")
        sys.exit(1)

    OUTPUT_DIR.mkdir(exist_ok=True)
    with db_cursor() as cur:
        ids = resolve_ids(cur, sys.argv[1:])
        for attempt_id in ids:
            attempt = fetch_attempt(cur, attempt_id)
            if attempt is None:
                print(f"{attempt_id}: not found")
                continue
            out = OUTPUT_DIR / f"{attempt_id}.json"
            out.write_text(to_json(attempt), encoding="utf-8")
            print(f"{attempt_id}: {len(attempt['Rounds'])} rounds -> {out}")


if __name__ == "__main__":
    main()
