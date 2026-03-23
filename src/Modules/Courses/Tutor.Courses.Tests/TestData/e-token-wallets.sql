-- Wallet events for learner -1 in course -1
INSERT INTO courses."WalletEvents"(
    "Id", "AggregateType", "AggregateId", "TimeStamp", "LearnerId", "CourseId", "DomainEvent")
VALUES (
    -1, 'Wallet', -1, '2024-01-01 10:00:00+00',
    -1, -1,
    '{{"$type":"WalletInitialized","InitialAllowance":2000000,"LearnerId":-1,"CourseId":-1,"TimeStamp":"2024-01-01T10:00:00Z"}}'::jsonb
);

-- Wallet events for learner -2 in course -1 (with some spending)
INSERT INTO courses."WalletEvents"(
    "Id", "AggregateType", "AggregateId", "TimeStamp", "LearnerId", "CourseId", "DomainEvent")
VALUES (
    -2, 'Wallet', -2, '2024-01-01 10:00:00+00',
    -2, -1,
    '{{"$type":"WalletInitialized","InitialAllowance":2000000,"LearnerId":-2,"CourseId":-1,"TimeStamp":"2024-01-01T10:00:00Z"}}'::jsonb
);

INSERT INTO courses."WalletEvents"(
    "Id", "AggregateType", "AggregateId", "TimeStamp", "LearnerId", "CourseId", "DomainEvent")
VALUES (
    -3, 'Wallet', -2, '2024-01-02 10:00:00+00',
    -2, -1,
    '{{"$type":"TokensSpent","UnitId":-1,"PromptTokens":100,"CompletionTokens":50,"FeatureType":"Kc","EntityId":1,"PromptSummary":"Test spending","LearnerId":-2,"CourseId":-1,"TimeStamp":"2024-01-02T10:00:00Z"}}'::jsonb
);

-- Wallet events for learner -3 in course -1 (with deposit)
INSERT INTO courses."WalletEvents"(
    "Id", "AggregateType", "AggregateId", "TimeStamp", "LearnerId", "CourseId", "DomainEvent")
VALUES (
    -4, 'Wallet', -3, '2024-01-01 10:00:00+00',
    -3, -1,
    '{{"$type":"WalletInitialized","InitialAllowance":2000000,"LearnerId":-3,"CourseId":-1,"TimeStamp":"2024-01-01T10:00:00Z"}}'::jsonb
);

INSERT INTO courses."WalletEvents"(
    "Id", "AggregateType", "AggregateId", "TimeStamp", "LearnerId", "CourseId", "DomainEvent")
VALUES (
    -5, 'Wallet', -3, '2024-01-03 10:00:00+00',
    -3, -1,
    '{{"$type":"TokensDeposited","Amount":500000,"Reason":"Bonus tokens","LearnerId":-3,"CourseId":-1,"TimeStamp":"2024-01-03T10:00:00Z"}}'::jsonb
);

-- TokenWallets projection (rebuilt from events)
INSERT INTO courses."TokenWallets"(
    "Id", "LearnerId", "CourseId", "TotalAllowance", "TotalSpent")
VALUES (-1, -1, -1, 2000000, 0);

INSERT INTO courses."TokenWallets"(
    "Id", "LearnerId", "CourseId", "TotalAllowance", "TotalSpent")
VALUES (-2, -2, -1, 2000000, 150);

INSERT INTO courses."TokenWallets"(
    "Id", "LearnerId", "CourseId", "TotalAllowance", "TotalSpent")
VALUES (-3, -3, -1, 2500000, 0);
