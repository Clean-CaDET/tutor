﻿CREATE TABLE "ArrangeTaskSubmissions" (
    "Id" integer NOT NULL GENERATED BY DEFAULT AS IDENTITY,
    "ArrangeTaskId" integer NOT NULL,
    "LearnerId" integer NOT NULL,
    "IsCorrect" boolean NOT NULL,
    "TimeStamp" timestamp without time zone NOT NULL,
    CONSTRAINT "PK_ArrangeTaskSubmissions" PRIMARY KEY ("Id")
);


CREATE TABLE "ChallengeHints" (
    "Id" integer NOT NULL GENERATED BY DEFAULT AS IDENTITY,
    "Content" text NULL,
    "LearningObjectSummaryId" integer NULL,
    CONSTRAINT "PK_ChallengeHints" PRIMARY KEY ("Id")
);


CREATE TABLE "ChallengeSubmissions" (
    "Id" integer NOT NULL GENERATED BY DEFAULT AS IDENTITY,
    "SourceCode" text[] NULL,
    "ChallengeId" integer NOT NULL,
    "LearnerId" integer NOT NULL,
    "IsCorrect" boolean NOT NULL,
    "TimeStamp" timestamp without time zone NOT NULL,
    CONSTRAINT "PK_ChallengeSubmissions" PRIMARY KEY ("Id")
);


CREATE TABLE "Courses" (
    "Id" integer NOT NULL GENERATED BY DEFAULT AS IDENTITY,
    CONSTRAINT "PK_Courses" PRIMARY KEY ("Id")
);


CREATE TABLE "Learners" (
    "Id" integer NOT NULL GENERATED BY DEFAULT AS IDENTITY,
    "StudentIndex" text NULL,
    "VisualScore" integer NOT NULL,
    "AuralScore" integer NOT NULL,
    "ReadWriteScore" integer NOT NULL,
    "KinaestheticScore" integer NOT NULL,
    CONSTRAINT "PK_Learners" PRIMARY KEY ("Id")
);


CREATE TABLE "LearningObjectFeedback" (
    "Id" integer NOT NULL GENERATED BY DEFAULT AS IDENTITY,
    "Rating" integer NOT NULL,
    "LearnerId" integer NOT NULL,
    "LearningObjectId" integer NOT NULL,
    "TimeStamp" timestamp without time zone NOT NULL,
    CONSTRAINT "PK_LearningObjectFeedback" PRIMARY KEY ("Id")
);


CREATE TABLE "QuestionSubmissions" (
    "Id" integer NOT NULL GENERATED BY DEFAULT AS IDENTITY,
    "SubmittedAnswerIds" integer[] NULL,
    "QuestionId" integer NOT NULL,
    "LearnerId" integer NOT NULL,
    "IsCorrect" boolean NOT NULL,
    "TimeStamp" timestamp without time zone NOT NULL,
    CONSTRAINT "PK_QuestionSubmissions" PRIMARY KEY ("Id")
);


CREATE TABLE "ArrangeTaskContainerSubmissions" (
    "Id" integer NOT NULL GENERATED BY DEFAULT AS IDENTITY,
    "ContainerId" integer NOT NULL,
    "ElementIds" integer[] NULL,
    "ArrangeTaskSubmissionId" integer NULL,
    CONSTRAINT "PK_ArrangeTaskContainerSubmissions" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_ArrangeTaskContainerSubmissions_ArrangeTaskSubmissions_Arra~" FOREIGN KEY ("ArrangeTaskSubmissionId") REFERENCES "ArrangeTaskSubmissions" ("Id") ON DELETE RESTRICT
);


CREATE TABLE "Lectures" (
    "Id" integer NOT NULL GENERATED BY DEFAULT AS IDENTITY,
    "CourseId" integer NOT NULL,
    "Name" text NULL,
    "Description" text NULL,
    CONSTRAINT "PK_Lectures" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Lectures_Courses_CourseId" FOREIGN KEY ("CourseId") REFERENCES "Courses" ("Id") ON DELETE CASCADE
);


CREATE TABLE "CourseEnrollment" (
    "Id" integer NOT NULL GENERATED BY DEFAULT AS IDENTITY,
    "CourseId" integer NOT NULL,
    "LearnerId" integer NULL,
    CONSTRAINT "PK_CourseEnrollment" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_CourseEnrollment_Learners_LearnerId" FOREIGN KEY ("LearnerId") REFERENCES "Learners" ("Id") ON DELETE RESTRICT
);


CREATE TABLE "KnowledgeNodes" (
    "Id" integer NOT NULL GENERATED BY DEFAULT AS IDENTITY,
    "LearningObjective" text NULL,
    "Type" integer NOT NULL,
    "LectureId" integer NOT NULL,
    CONSTRAINT "PK_KnowledgeNodes" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_KnowledgeNodes_Lectures_LectureId" FOREIGN KEY ("LectureId") REFERENCES "Lectures" ("Id") ON DELETE CASCADE
);


CREATE TABLE "LearningObjectSummaries" (
    "Id" integer NOT NULL GENERATED BY DEFAULT AS IDENTITY,
    "Description" text NULL,
    "KnowledgeNodeId" integer NULL,
    CONSTRAINT "PK_LearningObjectSummaries" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_LearningObjectSummaries_KnowledgeNodes_KnowledgeNodeId" FOREIGN KEY ("KnowledgeNodeId") REFERENCES "KnowledgeNodes" ("Id") ON DELETE RESTRICT
);


CREATE TABLE "NodeProgresses" (
    "Id" integer NOT NULL GENERATED BY DEFAULT AS IDENTITY,
    "LearnerId" integer NOT NULL,
    "NodeId" integer NULL,
    "Status" integer NOT NULL,
    CONSTRAINT "PK_NodeProgresses" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_NodeProgresses_KnowledgeNodes_NodeId" FOREIGN KEY ("NodeId") REFERENCES "KnowledgeNodes" ("Id") ON DELETE RESTRICT
);


CREATE TABLE "LearningObjects" (
    "Id" integer NOT NULL GENERATED BY DEFAULT AS IDENTITY,
    "LearningObjectSummaryId" integer NOT NULL,
    "NodeProgressId" integer NULL,
    CONSTRAINT "PK_LearningObjects" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_LearningObjects_NodeProgresses_NodeProgressId" FOREIGN KEY ("NodeProgressId") REFERENCES "NodeProgresses" ("Id") ON DELETE RESTRICT
);


CREATE TABLE "ArrangeTasks" (
    "Id" integer NOT NULL GENERATED BY DEFAULT AS IDENTITY,
    "Text" text NULL,
    CONSTRAINT "PK_ArrangeTasks" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_ArrangeTasks_LearningObjects_Id" FOREIGN KEY ("Id") REFERENCES "LearningObjects" ("Id") ON DELETE CASCADE
);


CREATE TABLE "Challenges" (
    "Id" integer NOT NULL GENERATED BY DEFAULT AS IDENTITY,
    "Url" text NULL,
    "Description" text NULL,
    "SolutionIdForeignKey" integer NOT NULL,
    CONSTRAINT "PK_Challenges" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Challenges_LearningObjects_Id" FOREIGN KEY ("Id") REFERENCES "LearningObjects" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_Challenges_LearningObjectSummaries_SolutionIdForeignKey" FOREIGN KEY ("SolutionIdForeignKey") REFERENCES "LearningObjectSummaries" ("Id") ON DELETE CASCADE
);


CREATE TABLE "Images" (
    "Id" integer NOT NULL GENERATED BY DEFAULT AS IDENTITY,
    "Url" text NULL,
    "Caption" text NULL,
    CONSTRAINT "PK_Images" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Images_LearningObjects_Id" FOREIGN KEY ("Id") REFERENCES "LearningObjects" ("Id") ON DELETE CASCADE
);


CREATE TABLE "Questions" (
    "Id" integer NOT NULL GENERATED BY DEFAULT AS IDENTITY,
    "Text" text NULL,
    CONSTRAINT "PK_Questions" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Questions_LearningObjects_Id" FOREIGN KEY ("Id") REFERENCES "LearningObjects" ("Id") ON DELETE CASCADE
);


CREATE TABLE "Texts" (
    "Id" integer NOT NULL GENERATED BY DEFAULT AS IDENTITY,
    "Content" text NULL,
    CONSTRAINT "PK_Texts" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Texts_LearningObjects_Id" FOREIGN KEY ("Id") REFERENCES "LearningObjects" ("Id") ON DELETE CASCADE
);


CREATE TABLE "Videos" (
    "Id" integer NOT NULL GENERATED BY DEFAULT AS IDENTITY,
    "Url" text NULL,
    CONSTRAINT "PK_Videos" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Videos_LearningObjects_Id" FOREIGN KEY ("Id") REFERENCES "LearningObjects" ("Id") ON DELETE CASCADE
);


CREATE TABLE "ArrangeTaskContainers" (
    "Id" integer NOT NULL GENERATED BY DEFAULT AS IDENTITY,
    "ArrangeTaskId" integer NOT NULL,
    "Title" text NULL,
    CONSTRAINT "PK_ArrangeTaskContainers" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_ArrangeTaskContainers_ArrangeTasks_ArrangeTaskId" FOREIGN KEY ("ArrangeTaskId") REFERENCES "ArrangeTasks" ("Id") ON DELETE CASCADE
);


CREATE TABLE "ChallengeFulfillmentStrategies" (
    "Id" integer NOT NULL GENERATED BY DEFAULT AS IDENTITY,
    "ChallengeId" integer NULL,
    CONSTRAINT "PK_ChallengeFulfillmentStrategies" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_ChallengeFulfillmentStrategies_Challenges_ChallengeId" FOREIGN KEY ("ChallengeId") REFERENCES "Challenges" ("Id") ON DELETE RESTRICT
);


CREATE TABLE "QuestionAnswers" (
    "Id" integer NOT NULL GENERATED BY DEFAULT AS IDENTITY,
    "QuestionId" integer NOT NULL,
    "Text" text NULL,
    "IsCorrect" boolean NOT NULL,
    "Feedback" text NULL,
    CONSTRAINT "PK_QuestionAnswers" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_QuestionAnswers_Questions_QuestionId" FOREIGN KEY ("QuestionId") REFERENCES "Questions" ("Id") ON DELETE CASCADE
);


CREATE TABLE "ArrangeTaskElements" (
    "Id" integer NOT NULL GENERATED BY DEFAULT AS IDENTITY,
    "ArrangeTaskContainerId" integer NOT NULL,
    "Text" text NULL,
    CONSTRAINT "PK_ArrangeTaskElements" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_ArrangeTaskElements_ArrangeTaskContainers_ArrangeTaskContai~" FOREIGN KEY ("ArrangeTaskContainerId") REFERENCES "ArrangeTaskContainers" ("Id") ON DELETE CASCADE
);


CREATE TABLE "BasicMetricCheckers" (
    "Id" integer NOT NULL GENERATED BY DEFAULT AS IDENTITY,
    CONSTRAINT "PK_BasicMetricCheckers" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_BasicMetricCheckers_ChallengeFulfillmentStrategies_Id" FOREIGN KEY ("Id") REFERENCES "ChallengeFulfillmentStrategies" ("Id") ON DELETE CASCADE
);


CREATE TABLE "BasicNameCheckers" (
    "Id" integer NOT NULL GENERATED BY DEFAULT AS IDENTITY,
    "BannedWords" text[] NULL,
    "RequiredWords" text[] NULL,
    "HintId" integer NULL,
    CONSTRAINT "PK_BasicNameCheckers" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_BasicNameCheckers_ChallengeFulfillmentStrategies_Id" FOREIGN KEY ("Id") REFERENCES "ChallengeFulfillmentStrategies" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_BasicNameCheckers_ChallengeHints_HintId" FOREIGN KEY ("HintId") REFERENCES "ChallengeHints" ("Id") ON DELETE RESTRICT
);


CREATE TABLE "MetricRangeRules" (
    "Id" integer NOT NULL GENERATED BY DEFAULT AS IDENTITY,
    "MetricName" text NULL,
    "FromValue" double precision NOT NULL,
    "ToValue" double precision NOT NULL,
    "HintId" integer NULL,
    "ClassMetricCheckerForeignKey" integer NULL,
    "MethodMetricCheckerForeignKey" integer NULL,
    CONSTRAINT "PK_MetricRangeRules" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_MetricRangeRules_BasicMetricCheckers_ClassMetricCheckerFore~" FOREIGN KEY ("ClassMetricCheckerForeignKey") REFERENCES "BasicMetricCheckers" ("Id") ON DELETE RESTRICT,
    CONSTRAINT "FK_MetricRangeRules_BasicMetricCheckers_MethodMetricCheckerFor~" FOREIGN KEY ("MethodMetricCheckerForeignKey") REFERENCES "BasicMetricCheckers" ("Id") ON DELETE RESTRICT,
    CONSTRAINT "FK_MetricRangeRules_ChallengeHints_HintId" FOREIGN KEY ("HintId") REFERENCES "ChallengeHints" ("Id") ON DELETE RESTRICT
);


CREATE INDEX "IX_ArrangeTaskContainers_ArrangeTaskId" ON "ArrangeTaskContainers" ("ArrangeTaskId");


CREATE INDEX "IX_ArrangeTaskContainerSubmissions_ArrangeTaskSubmissionId" ON "ArrangeTaskContainerSubmissions" ("ArrangeTaskSubmissionId");


CREATE INDEX "IX_ArrangeTaskElements_ArrangeTaskContainerId" ON "ArrangeTaskElements" ("ArrangeTaskContainerId");


CREATE INDEX "IX_BasicNameCheckers_HintId" ON "BasicNameCheckers" ("HintId");


CREATE INDEX "IX_ChallengeFulfillmentStrategies_ChallengeId" ON "ChallengeFulfillmentStrategies" ("ChallengeId");


CREATE INDEX "IX_Challenges_SolutionIdForeignKey" ON "Challenges" ("SolutionIdForeignKey");


CREATE INDEX "IX_CourseEnrollment_LearnerId" ON "CourseEnrollment" ("LearnerId");


CREATE INDEX "IX_KnowledgeNodes_LectureId" ON "KnowledgeNodes" ("LectureId");


CREATE INDEX "IX_LearningObjects_NodeProgressId" ON "LearningObjects" ("NodeProgressId");


CREATE INDEX "IX_LearningObjectSummaries_KnowledgeNodeId" ON "LearningObjectSummaries" ("KnowledgeNodeId");


CREATE INDEX "IX_Lectures_CourseId" ON "Lectures" ("CourseId");


CREATE INDEX "IX_MetricRangeRules_ClassMetricCheckerForeignKey" ON "MetricRangeRules" ("ClassMetricCheckerForeignKey");


CREATE INDEX "IX_MetricRangeRules_HintId" ON "MetricRangeRules" ("HintId");


CREATE INDEX "IX_MetricRangeRules_MethodMetricCheckerForeignKey" ON "MetricRangeRules" ("MethodMetricCheckerForeignKey");


CREATE INDEX "IX_NodeProgresses_NodeId" ON "NodeProgresses" ("NodeId");


CREATE INDEX "IX_QuestionAnswers_QuestionId" ON "QuestionAnswers" ("QuestionId");


