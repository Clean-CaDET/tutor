import sys
import re
from pathlib import Path

from common import db_cursor, to_json, parse_json_field

OUTPUT_DIR = Path(__file__).parent / "data/records"

SQL = """
SELECT
    cet."Id",
    cet."Title",
    cet."Description",
    cr."CanonicalDefinition",
    cr."KeyPropositions"
FROM elaborations."ConceptRecords" cr
JOIN elaborations."ConceptElaborationTasks" cet
    ON cr."ConceptElaborationTaskId" = cet."Id"
"""


def build_record(row):
    return {
        "Id": row["Id"],
        "Title": row["Title"],
        "Description": row["Description"],
        "CanonicalDefinition": row["CanonicalDefinition"],
        "KeyPropositions": parse_json_field(row["KeyPropositions"]),
    }


def get_records(cursor, ids=None):
    if ids is None:
        cursor.execute(SQL)
    else:
        placeholders = ",".join(["%s"] * len(ids))
        cursor.execute(SQL + f' WHERE cet."Id" IN ({placeholders})', ids)
    return [build_record(row) for row in cursor.fetchall()]


def resolve_ids(cursor, args):
    if not args:
        return None
    if len(args) == 1 and re.fullmatch(r'\d+\+', args[0]):
        min_id = int(args[0][:-1])
        cursor.execute(
            'SELECT "Id" FROM elaborations."ConceptElaborationTasks" WHERE "Id" >= %s ORDER BY "Id"',
            (min_id,)
        )
        return [row["Id"] for row in cursor.fetchall()]
    return [int(arg) for arg in args]


def main():
    OUTPUT_DIR.mkdir(exist_ok=True)
    with db_cursor() as cur:
        ids = resolve_ids(cur, sys.argv[1:])
        for record in get_records(cur, ids):
            out = OUTPUT_DIR / f"{record['Id']}.json"
            out.write_text(to_json(record), encoding="utf-8")
            print(f"{record['Id']}: {record['Title']} -> {out}")


if __name__ == "__main__":
    main()
