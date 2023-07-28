INSERT INTO "lmConversations"."Conversations"(
    "Id", "LearnerId", "ContextId", "LmMessages", "Messages")
VALUES (-1, -1, -1, '[
  {{
    "Data": {{
      "Content": "Sistemka poruka"
    }},
    "Type": "system"
  }},
  {{
    "Data": {{
      "Content": "Korisnicka poruka"
    }},
    "Type": "human"
  }},
  {{
    "Data": {{
      "Content": "Odgovor"
    }},
    "Type": "ai"
  }}
]', '[ {{ "Sender": 0, "Message": "Korisnicka poruka" }}, {{ "Sender": 1, "Message": "Odgovor" }} ]');

INSERT INTO "lmConversations"."Tokens"(
    "Id", "LearnerId", "Count")
VALUES (-1, -1, 199300);
