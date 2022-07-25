
DELETE FROM public."AssessmentItemMasteries";
DELETE FROM public."KcMasteries";
DELETE FROM public."UnitEnrollments";
DELETE FROM public."GroupMemberships";
DELETE FROM public."LearnerGroups";
DELETE FROM public."Learners";
DELETE FROM public."Events";
DELETE FROM public."Users";

DELETE FROM public."Texts";
DELETE FROM public."Images";
DELETE FROM public."Videos";
DELETE FROM public."BasicMetricCheckers";
DELETE FROM public."BannedWordsCheckers";
DELETE FROM public."RequiredWordsCheckers";
DELETE FROM public."ChallengeHints";
DELETE FROM public."ChallengeFulfillmentStrategies";
DELETE FROM public."Challenges";
DELETE FROM public."MrqItems";
DELETE FROM public."MultiResponseQuestions";
DELETE FROM public."ArrangeTaskElements";
DELETE FROM public."ArrangeTaskContainers";
DELETE FROM public."ArrangeTasks";
DELETE FROM public."ShortAnswerQuestions";
DELETE FROM public."AssessmentItems";
DELETE FROM public."InstructionalItems";
DELETE FROM public."KnowledgeComponents";
DELETE FROM public."KnowledgeUnits";
INSERT INTO public."KnowledgeUnits"("Id", "Code", "Name", "Description") VALUES
	(-100, 'TT00', 'Tutor interaction tutorial', 'As part of this *unit*, you will get acquainted with the basic building blocks of the Clean CaDET Tutor. You will understand how to interact with the different types of *instructional* and *assessment items*.

For starters, examine the *skill* list provided below. "Create a submission for a refactoring challenge" is a higher-level skill you unlock once you master all the related subskills. Unlocked skills start with 0% *mastery*, where this number increases as you provide (correct) answers to assessment items.

Now, select one of the unlocked skills and access its instructional items. From there, move on to its assessment items. Once you achieve sufficient mastery, move on to the next skill until you have mastered all the skills in this unit.');

INSERT INTO public."KnowledgeComponents"("Id", "Code", "Name", "Description", "KnowledgeUnitId", "ParentId") VALUES
	(-100, 'T01', 'Create a submission for a refactoring challenge', '', -100, NULL);

INSERT INTO public."KnowledgeComponents"("Id", "Code", "Name", "Description", "KnowledgeUnitId", "ParentId") VALUES
	(-99, 'T02', 'Analyze the different types of instructional items', '', -100, -100);

INSERT INTO public."KnowledgeComponents"("Id", "Code", "Name", "Description", "KnowledgeUnitId", "ParentId") VALUES
	(-98, 'T03', 'Create submissions for the basic assessment item types', '', -100, -100);

INSERT INTO public."InstructionalItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-1000, -100, 1);
INSERT INTO public."Texts"("Id", "Content") VALUES
	(-1000, 'Until now, we have examined the generic instructional and assessment item types that we can use to support skill development for any domain. We will now explore an assessment item type specialized for the field of software engineering.

The **refactoring challenge** specializes in developing procedural knowledge for code quality analysis and refactoring. The learning instrument through which you can submit an answer to this assessment item type is a plugin for the Visual Studio Code IDE. The following video explains how to install and use the plugin.');

INSERT INTO public."InstructionalItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-999, -100, 2);
INSERT INTO public."Videos"("Id", "Url") VALUES
	(-999, 'https://www.youtube.com/watch?v=GEUTc-q2juw');

INSERT INTO public."InstructionalItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-998, -99, 1);
INSERT INTO public."Texts"("Id", "Content") VALUES
	(-998, 'The first step in developing your skills entails analyzing instructional items related to that skill. The current version of the Tutor presents instructions through:

- Formatted (markdown) text,
- Images, and
- Videos.

Once you analyze and understand all the instructions, you can move on to answering assessment items. You can return to the instructions as you solve the assessment items. However, it would be best if you strived to strain yourself to formulate an answer before checking the instructions, as most of the learning occurs during this difficulty.');

INSERT INTO public."InstructionalItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-997, -99, 2);
INSERT INTO public."Images"("Id", "Url", "Caption") VALUES
	(-997, 'https://i.ibb.co/8BNsVDp/themes.png', 'The Tutor supports the light and dark theme, so adjust your learning according to your preferences and time of day.');

INSERT INTO public."InstructionalItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-996, -99, 3);
INSERT INTO public."Videos"("Id", "Url") VALUES
	(-996, 'https://youtu.be/3DZDotjzL5o');

INSERT INTO public."InstructionalItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-995, -98, 1);
INSERT INTO public."Texts"("Id", "Content") VALUES
	(-995, 'The Tutor supports several assessment item types that assess your skill development through different interaction patterns. Each type provides feedback on the correctness of your submission and often additional instructions that help you understand why an answer is (in)correct.

The following illustrations highlight the different assessment item types and their main components.');

INSERT INTO public."InstructionalItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-994, -98, 2);
INSERT INTO public."Images"("Id", "Url", "Caption") VALUES
	(-994, 'https://i.ibb.co/whdS7Fx/mrq.png', 'Important components of the "multiple response question" assessment item type, where we can have 0, 1 or more correct answers.');

INSERT INTO public."InstructionalItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-993, -98, 3);
INSERT INTO public."Images"("Id", "Url", "Caption") VALUES
	(-993, 'https://i.ibb.co/2FC2jMM/saq.png', 'Important components of the "short answer question" assessment item type, where the answer can have 0, 1 or more words (delimited by a comma).');

INSERT INTO public."InstructionalItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-992, -98, 4);
INSERT INTO public."Images"("Id", "Url", "Caption") VALUES
	(-992, 'https://i.ibb.co/MRbk0gz/at.png', 'Important components of the "arrange task" assessment item type, where each category can have 0, 1 or more elements that belong to it.');

INSERT INTO public."InstructionalItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-991, -98, 5);
INSERT INTO public."Texts"("Id", "Content") VALUES
	(-991, 'After submitting an answer, the Tutor determines its correctness and potentially updates your skill mastery. You progress over the assessment items until you reach a sufficient level of mastery. Should the Tutor run out of assessment items, it will offer those for which you achieved the lowest correctness.

You may now move on to the assessments to examine the different interaction patterns.');

INSERT INTO public."AssessmentItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-1000, -100, 1);
INSERT INTO public."Challenges"("Id", "Description", "Url", "TestSuiteLocation", "SolutionUrl") VALUES
	(-1000, 'Your goal is to get acquainted with the refactoring challenge assessment item type. You need to:

1. Install the VS Code plugin following the video from the instructions page,
2. Download the starting code from the **Retrieve challenge code** button below and load it into the VS Code,
3. Follow the instructions written in the *Sample/01. Simple Name Challenge/Start.cs* file to completion.
4. Click the **Refresh submission correctness** button below.', 'https://github.com/Clean-CaDET/sample-challenges', 'Sample.Name', 'https://gist.github.com/Luburic/2ad6db4c02c11ed221d1d2b6d82d1aed#file-start-cs');

INSERT INTO public."ChallengeHints"(
	"Id", "Content")
	VALUES (-1, 'The goal of "hints" is to guide the thinking process without explicilty showing the solution. For this hint we will make an exception - your task is to rename the "Challenge" field to "_completed".');
INSERT INTO public."ChallengeFulfillmentStrategies"(
	"Id", "ChallengeId")
	VALUES (-1, -1000);
INSERT INTO public."BannedWordsCheckers"(
	"Id", "BannedWords", "HintId")
	VALUES (-1, '{"Challenge"}', -1);
INSERT INTO public."ChallengeFulfillmentStrategies"(
	"Id", "ChallengeId")
	VALUES (-2, -1000);
INSERT INTO public."RequiredWordsCheckers"(
	"Id", "RequiredWords", "HintId")
	VALUES (-2, '{"_completed"}', -1);


INSERT INTO public."AssessmentItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-999, -100, -1);
INSERT INTO public."Challenges"("Id", "Description", "Url", "TestSuiteLocation", "SolutionUrl") VALUES
	(-999, 'Your goal is to get acquainted with the refactoring challenge assessment item type. You need to:

1. Follow the instructions written in the *Sample/02. Simple Metric Challenge/Start.cs* file to completion.
2. Click the **Refresh submission correctness** button below once you have completed the challenge.', 'https://github.com/Clean-CaDET/sample-challenges', 'Sample.Metrics', 'https://gist.github.com/Luburic/16ad8833545b503d3d54c4adc42f9121#file-metric-start-cs');

INSERT INTO public."ChallengeHints"(
	"Id", "Content")
	VALUES (-2, 'Your goal is to end up with 2 or 3 methods, each with 3 lines of code or less (not counting method headers and parenthesis.');
INSERT INTO public."ChallengeFulfillmentStrategies"(
	"Id", "ChallengeId")
	VALUES (-3, -999);
INSERT INTO public."BasicMetricCheckers"(
	"Id", "MetricName", "FromValue", "ToValue", "HintId")
	VALUES (-3, 'MELOC', 0, 3, -2);


INSERT INTO public."AssessmentItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-998, -99, 1);
INSERT INTO public."MultiResponseQuestions"("Id", "Text") VALUES
	(-998, 'Mark the correct statements from the following list.');
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-9980, 'The Tutor organizes its content into units which are divided into modules. Each module consists of skills and instructional items.', false, 'This statement is incorrect.', -998);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-9981, 'The Tutor organizes its content into units, which are divided into skills. Instructional and assessment items are connected to each skill.', true, 'This statement is correct.', -998);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-9982, 'The Tutor supports three UI themes: light, dark, and gray.', false, 'This statement is incorrect.', -998);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-9983, 'The Tutor supports note-taking.', true, 'This statement is correct.', -998);


INSERT INTO public."AssessmentItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-997, -98, 1);
INSERT INTO public."MultiResponseQuestions"("Id", "Text") VALUES
	(-997, 'The following list contains claims about the Tutor. Your goal is to mark the correct statements. Do not worry if you do not know the answer - the goal is to understand how the Tutor evaluates incorrect submissions. Ensure you read and understand the feedback, as you will get another opportunity to correct your answer.');
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-9970, 'The goal of the Tutor is to optimize your learning.', true, 'This statement is correct. The Tutor assesses your skill mastery and allows you to move on when you achieve it.', -997);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-9971, 'The Tutor focuses on skills that you need to develop.', true, 'This statement is correct. Your goal is to develop competencies for a particular domain. To achieve this, you need to understand the knowledge presented in the instructional items and use it to employ the related skills to solve assessment items.', -997);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-9972, 'The Tutor is specialized in developing skills from any engineering domain.', false, 'This statement is incorrect. Our Tutor is an expert system specialized in software engineering through its coding and refactoring challenge subsystem.', -997);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-9973, 'The Tutor monitors your interaction with it.', true, 'This statement is correct. The Tutor persists many different events generated through your interaction with it, aiming to understand you and optimize your learning experience.', -997);


INSERT INTO public."AssessmentItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-996, -98, 2);
INSERT INTO public."ShortAnswerQuestions"("Id", "Text", "AcceptableAnswers") VALUES
	(-996, 'Using the **View instructions** button below, return to the instructional items and examine copy the third word that appears in the first paragraph as your answer here.', '{"supports"}');

INSERT INTO public."AssessmentItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-995, -98, 3);
INSERT INTO public."ArrangeTasks"("Id", "Text") VALUES
	(-995, 'Distribute the following statements (using drag and drop) to the assessment item type (category) for which they are true.');
INSERT INTO public."ArrangeTaskContainers"("Id", "ArrangeTaskId", "Title") VALUES
	(-9950, -995, 'Multiple response question');
INSERT INTO public."ArrangeTaskElements"("Id", "ArrangeTaskContainerId", "Text", "Feedback") VALUES
	(-99500,-9950, 'A series of statements where you must select which are true.', 'Remember: There can be 0, 1, or more true statements.');
INSERT INTO public."ArrangeTaskContainers"("Id", "ArrangeTaskId", "Title") VALUES
	(-9951, -995, 'Short answer question');
INSERT INTO public."ArrangeTaskElements"("Id", "ArrangeTaskContainerId", "Text", "Feedback") VALUES
	(-99510,-9951, 'It is necessary to write 0, 1, or more words delimited by a comma.', 'Remember: The feedback includes a list of acceptable answers, delimited by a semicolon if more acceptable answers exist.');
INSERT INTO public."ArrangeTaskContainers"("Id", "ArrangeTaskId", "Title") VALUES
	(-9952, -995, 'Arrange tasks');
INSERT INTO public."ArrangeTaskElements"("Id", "ArrangeTaskContainerId", "Text", "Feedback") VALUES
	(-99520,-9952, 'It is necessary to distribute elements between categories, where each category might have 0, 1, or more elements.', 'Remember: An incorrectly placed element contains an "X" at the location it is placed and appears in a different color in the correct category, along with additional feedback.');





INSERT INTO public."LearnerGroups"("Id", "Name") VALUES
	(-996, 'Test Group');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-1000, 'TT-1-2022', 'Jcg0hGH+PnP143hLxNy48P+8uPPvFraABwFbxitrwoY=', 'HfyKrwl3VlxIzofFKZ4KXw==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-1000, -1000, 'TT-1-2022', 'Smith', 'Alice');

INSERT INTO public."GroupMemberships"("Id", "LearnerId", "LearnerGroupId") VALUES
	(-1000, -1000, -996);

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-999, 'TT-2-2022', 'gtb6FeyKvn5uBZXhRwibpOl8kDgqexaKfOiZzJDqcZ8=', 'tn0jL41lS4o1KRsCp3k6cA==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-999, -999, 'TT-2-2022', 'Smith', 'Bob');

INSERT INTO public."GroupMemberships"("Id", "LearnerId", "LearnerGroupId") VALUES
	(-999, -999, -996);

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-998, 'TT-3-2022', 'IlRmhRZNdf7td5qLW2dL5VLajwrbp3sJOIpbq1PR0ts=', '3B/cmjp8Ey/acIHZB+MXow==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-998, -998, 'TT-3-2022', 'Smith', 'Carl');

INSERT INTO public."GroupMemberships"("Id", "LearnerId", "LearnerGroupId") VALUES
	(-998, -998, -996);

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-997, 'TT-4-2022', 'xHXGBLs3R/FwMevLCVjmZPUEzh+HFNz39MWM3Z5QKwY=', 'XGY5hgC9rvX53sFyxzZ8KQ==', 1);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-997, -997, 'TT-4-2022', 'Smith', 'Dave');


INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9999, -1000, -100, '7/13/2022 11:20:54 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted", "HasActiveSession") VALUES
	(-9999, 0.00, -100, -1000, false, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-100000, -999, 0.00, 0, NULL, -9999);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99999, -1000, 0.00, 0, NULL, -9999);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted", "HasActiveSession") VALUES
	(-9998, 0.00, -99, -1000, false, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99998, -998, 0.00, 0, NULL, -9998);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted", "HasActiveSession") VALUES
	(-9997, 0.00, -98, -1000, false, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99997, -997, 0.00, 0, NULL, -9997);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99996, -996, 0.00, 0, NULL, -9997);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99995, -995, 0.00, 0, NULL, -9997);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9998, -999, -100, '7/13/2022 11:20:54 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted", "HasActiveSession") VALUES
	(-9996, 0.00, -100, -999, false, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99994, -999, 0.00, 0, NULL, -9996);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99993, -1000, 0.00, 0, NULL, -9996);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted", "HasActiveSession") VALUES
	(-9995, 0.00, -99, -999, false, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99992, -998, 0.00, 0, NULL, -9995);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted", "HasActiveSession") VALUES
	(-9994, 0.00, -98, -999, false, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99991, -997, 0.00, 0, NULL, -9994);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99990, -996, 0.00, 0, NULL, -9994);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99989, -995, 0.00, 0, NULL, -9994);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9997, -998, -100, '7/13/2022 11:20:54 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted", "HasActiveSession") VALUES
	(-9993, 0.00, -100, -998, false, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99988, -999, 0.00, 0, NULL, -9993);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99987, -1000, 0.00, 0, NULL, -9993);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted", "HasActiveSession") VALUES
	(-9992, 0.00, -99, -998, false, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99986, -998, 0.00, 0, NULL, -9992);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted", "HasActiveSession") VALUES
	(-9991, 0.00, -98, -998, false, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99985, -997, 0.00, 0, NULL, -9991);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99984, -996, 0.00, 0, NULL, -9991);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99983, -995, 0.00, 0, NULL, -9991);
