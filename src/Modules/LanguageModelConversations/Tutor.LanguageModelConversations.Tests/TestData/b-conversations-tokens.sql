INSERT INTO "languageModelConversations"."Conversations"(
    "Id", "LearnerId", "Group", "ContextId", "Messages")
VALUES (-1, -2, 0, -11, 
'[ {{ "SenderType": 0, "MessageType": 0, "Content": "Sistemska poruka" }}, 
{{ "SenderType": 1, "MessageType": 0, "Content": "Korisnicka poruka" }}, 
{{ "SenderType": 2, "MessageType": 0, "Content": "Odgovor" }} ]'
);
INSERT INTO "languageModelConversations"."Conversations"(
    "Id", "LearnerId", "Group", "ContextId", "Messages")
VALUES (-2, -2, 0, -14, 
'[ {{ "SenderType": 0, "MessageType": 0, "Content": "Sistemska poruka" }}, 
{{ "SenderType": 1, "MessageType": 0, "Content": "Korisnicka poruka" }}, 
{{ "SenderType": 2, "MessageType": 0, "Content": "Odgovor" }} ]'
);

INSERT INTO "languageModelConversations"."TokenWallets"(
    "Id", "LearnerId", "CourseId", "Amount")
VALUES (-1, -2, -1, 199300);

INSERT INTO "languageModelConversations"."Summarizations"(
    "Id", "ContextId", "Group", "Messages")
VALUES (-1, -11, 0, 
'[ {{ "SenderType": 0, "MessageType": 0, "Content": "Sistemska poruka" }}, 
{{ "SenderType": 1, "MessageType": 0, "Content": "Zatrazena sumarizacija" }}, 
{{ "SenderType": 2, "MessageType": 0, "Content": "Sumarizacija" }} ]'
);
