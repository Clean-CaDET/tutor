import sys
import json
import re
import psycopg2
import psycopg2.extras
from pathlib import Path

DSN = "host=localhost port=5432 dbname=tutor-v9 user=postgres password=admin options='-c search_path=elaborations,public'"

SQL_PATH = Path(__file__).parent / "conversation-rounds.sql"
OUTPUT_DIR = Path(__file__).parent / "conversations"


def to_json(data):
    raw = json.dumps(data, indent=2, default=str, ensure_ascii=False)
    # Collapse flat objects (no nested {} or []) onto a single line
    return re.sub(r'\{[^{}\[\]]*\}', lambda m: re.sub(r'\s+', ' ', m.group()), raw, flags=re.DOTALL)


def load_sql():
    return SQL_PATH.read_text().replace("?", "%s")


def fetch_rounds(cursor, attempt_id):
    cursor.execute(load_sql(), (attempt_id,))
    results = []
    for row in cursor.fetchall():
        evaluation = None
        if row["RoundEvaluationId"] is not None:
            evaluation = {
                "RoundEvaluationId": row["RoundEvaluationId"],
                "Assessments": row["Assessments"],
                "TriggeredMisconceptions": row["TriggeredMisconceptions"],
            }
        results.append({
            "ConversationRoundId": row["ConversationRoundId"],
            "ConversationAttemptId": row["ConversationAttemptId"],
            "Order": row["Order"],
            "ElaborationContent": row["ElaborationContent"],
            "SubmittedAt": str(row["SubmittedAt"]),
            "FeedbackContent": row["FeedbackContent"],
            "Probes": row["Probes"],
            "Evaluation": evaluation,
        })
    return results


def main():
    if len(sys.argv) < 2:
        print("Usage: python fetch_conversations.py <id1> [id2] ...")
        sys.exit(1)

    ids = [int(arg) for arg in sys.argv[1:]]
    OUTPUT_DIR.mkdir(exist_ok=True)

    conn = psycopg2.connect(DSN)
    try:
        with conn.cursor(cursor_factory=psycopg2.extras.RealDictCursor) as cur:
            for attempt_id in ids:
                rounds = fetch_rounds(cur, attempt_id)
                out = OUTPUT_DIR / f"{attempt_id}.json"
                out.write_text(to_json(rounds), encoding="utf-8")
                print(f"{attempt_id}: {len(rounds)} rounds -> {out}")
    finally:
        conn.close()


if __name__ == "__main__":
    main()
