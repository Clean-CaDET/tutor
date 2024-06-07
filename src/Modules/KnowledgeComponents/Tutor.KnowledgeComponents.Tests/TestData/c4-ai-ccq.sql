INSERT INTO "knowledgeComponents"."AssessmentItems"(
    "Id", "KnowledgeComponentId", "Order")
VALUES (-41, -41, 1);
INSERT INTO "knowledgeComponents"."CodeCompletionQuestions"(
	"Id", "Text", "Feedback", "Code", "Items")
	VALUES (-41, 'Test', 'Test',
    'int brDana = 22;
int brSati = 12;

$$1$$;
int brKonobara = 2;

double satnicaKuvara = 1000.00;
double $$2$$;
$$3$$;
double fiksniTroskovi = 900.00 * 118;',
    '[{{
        "Order": 1,
        "Answer": "int brKuvara = 1",
        "Length": 16,
        "IgnoreSpace": false
    }},
    {{
        "Order": 2,
        "Answer": "satnicaKonobara = 300.00",
        "Length": 24,
        "IgnoreSpace": false
    }},
    {{
        "Order": 3,
        "Answer": "satnicaKonobara = 500.00",
        "Length": 24,
        "IgnoreSpace": true
    }}]');