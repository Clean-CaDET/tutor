import json
import re
from contextlib import contextmanager
from pathlib import Path

import psycopg2
import psycopg2.extras

DSN = json.loads((Path(__file__).parent / "util.config").read_text())["dsn"]


@contextmanager
def db_cursor():
    conn = psycopg2.connect(DSN)
    try:
        with conn.cursor(cursor_factory=psycopg2.extras.RealDictCursor) as cur:
            yield cur
    finally:
        conn.close()


def to_json(data):
    raw = json.dumps(data, indent=2, default=str, ensure_ascii=False)
    # Collapse flat objects (no nested {} or []) onto a single line
    return re.sub(r'\{[^{}\[\]]*\}', lambda m: re.sub(r'\s+', ' ', m.group()), raw, flags=re.DOTALL)


def parse_json_field(value):
    if isinstance(value, str):
        return json.loads(value)
    return value
