import re
import argparse
from pathlib import Path

from common import db_cursor, to_json
import fetch_records
import fetch_conversations

DEFAULT_RESULTS_DIR = Path(__file__).parent / "data/results"


def safe_folder_name(record):
    title = re.sub(r'[<>:"/\\|?*]', "_", record["Title"]).strip(" .")
    return f"{record['Id']} - {title}"


def write_conversation(folder, messages_dir, attempt):
    attempt_id = attempt["Id"]
    (folder / f"conversation-{attempt_id}.json").write_text(to_json(attempt), encoding="utf-8")

    messages = "\n---\n".join(r["ElaborationContent"] for r in attempt["Rounds"])
    (messages_dir / f"conversation-{attempt_id}.txt").write_text(messages, encoding="utf-8")


def main():
    parser = argparse.ArgumentParser(
        description="Fetch concept elaboration records with their conversations."
    )
    parser.add_argument(
        "ids", nargs="*",
        help="Task ids to fetch (e.g. 1 2 3 or 5+). Omit to fetch all records."
    )
    parser.add_argument(
        "-o", "--output", type=Path, default=DEFAULT_RESULTS_DIR,
        help=f"Output directory (default: {DEFAULT_RESULTS_DIR})"
    )
    args = parser.parse_args()

    results_dir = args.output
    results_dir.mkdir(parents=True, exist_ok=True)
    with db_cursor() as cur:
        ids = fetch_records.resolve_ids(cur, args.ids)
        for record in fetch_records.get_records(cur, ids):
            folder = results_dir / safe_folder_name(record)
            messages_dir = folder / "messages"
            messages_dir.mkdir(parents=True, exist_ok=True)

            (folder / "record.json").write_text(to_json(record), encoding="utf-8")

            attempt_ids = fetch_conversations.fetch_attempt_ids_for_task(cur, record["Id"])
            for attempt_id in attempt_ids:
                write_conversation(folder, messages_dir, fetch_conversations.fetch_attempt(cur, attempt_id))

            print(f"{record['Id']}: {record['Title']} -> {folder} ({len(attempt_ids)} conversations)")


if __name__ == "__main__":
    main()
