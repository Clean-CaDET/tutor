import sys
import json
import re
import psycopg2
import psycopg2.extras
from pathlib import Path

CONFIG = json.loads((Path(__file__).parent / "util.config").read_text())
DSN = CONFIG["dsn"]

OUTPUT_DIR = Path(__file__).parent / "data/records"

SQL = """
SELECT
    cet."Id",
    cet."Title",
    cet."Description",
    cr."KeyPropositions",
    cr."CommonMisconceptions",
    cr."KeyRelations"
FROM elaborations."ConceptRecords" cr
JOIN elaborations."ConceptElaborationTasks" cet
    ON cr."ConceptElaborationTaskId" = cet."Id"
"""


def to_json(data):
    raw = json.dumps(data, indent=2, default=str, ensure_ascii=False)
    return re.sub(r'\{[^{}\[\]]*\}', lambda m: re.sub(r'\s+', ' ', m.group()), raw, flags=re.DOTALL)


def parse_json_field(value):
    if isinstance(value, str):
        return json.loads(value)
    return value


def fetch_all(cursor):
    cursor.execute(SQL)
    return cursor.fetchall()


def fetch_by_ids(cursor, ids):
    placeholders = ",".join(["%s"] * len(ids))
    cursor.execute(SQL + f' WHERE cet."Id" IN ({placeholders})', ids)
    return cursor.fetchall()


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

    conn = psycopg2.connect(DSN)
    try:
        with conn.cursor(cursor_factory=psycopg2.extras.RealDictCursor) as cur:
            ids = resolve_ids(cur, sys.argv[1:])
            rows = fetch_by_ids(cur, ids) if ids is not None else fetch_all(cur)
            for row in rows:
                record = {
                    "Id": row["Id"],
                    "Title": row["Title"],
                    "Description": row["Description"],
                    "KeyPropositions": parse_json_field(row["KeyPropositions"]),
                    "CommonMisconceptions": parse_json_field(row["CommonMisconceptions"]),
                    "KeyRelations": parse_json_field(row["KeyRelations"]),
                }
                out = OUTPUT_DIR / f"{row['Id']}.json"
                out.write_text(to_json(record), encoding="utf-8")
                print(f"{row['Id']}: {row['Title']} -> {out}")
    finally:
        conn.close()


if __name__ == "__main__":
    main()
