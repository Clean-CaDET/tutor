using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tutor.Infrastructure.Database.DataImport.Domain.DomainExcelModel;
using Tutor.Infrastructure.Database.DataImport.Enrollment.EnrollmentExcelModel;
using Tutor.Infrastructure.Database.DataImport.Learner;

namespace Tutor.Infrastructure.Database.DataImport.Enrollment
{
    internal class EnrollmentToSqlTransformer
    {
        public static string Transform(EnrollmentExcelContent enrollmentContent, DomainExcelContent domainContent, List<UserLearnerColumns> learners)
        {
            var sqlBuilder = new StringBuilder();
            sqlBuilder.Append(BuildInstructorsSql(enrollmentContent.Instructors));
            sqlBuilder.Append(BuildLearnerGroupsSql(enrollmentContent, domainContent.Courses, learners));
            sqlBuilder.Append(BuildMasteries(enrollmentContent, domainContent, learners));

            return sqlBuilder.ToString();
        }

        private static string BuildInstructorsSql(List<InstructorColumns> instructors)
        {
            var sqlBuilder = new StringBuilder();
            sqlBuilder.AppendLine().AppendLine();
            foreach (var instructor in instructors)
            {
                sqlBuilder.Append("INSERT INTO public.\"Users\"(\"Id\", \"Username\", \"Password\", \"Salt\", \"Role\") VALUES");
                sqlBuilder.AppendLine();
                sqlBuilder.Append("\t(" + instructor.Id + ", '" + instructor.Username + "', '"
                                  + instructor.Password + "', '" + instructor.Salt + "', 1);");
                sqlBuilder.AppendLine().AppendLine();

                sqlBuilder.Append("INSERT INTO public.\"Instructors\"(\"Id\", \"UserId\", \"Name\", \"Surname\") VALUES");
                sqlBuilder.AppendLine();
                sqlBuilder.Append("\t(" + instructor.Id + ", " + instructor.Id + ", '"
                                  + instructor.Name + "', '" + instructor.Surname + "');");
                sqlBuilder.AppendLine().AppendLine();

            }
            return sqlBuilder.ToString();
        }

        private static string BuildLearnerGroupsSql(EnrollmentExcelContent enrollmentContent, List<CourseColumns> courses, List<UserLearnerColumns> learners)
        {
            var sqlBuilder = new StringBuilder();
            sqlBuilder.AppendLine().AppendLine();
            foreach (var group in enrollmentContent.CourseGroups)
            {
                var course = courses.Find(c => c.Code.Equals(group.CourseCode));
                if(course == null) continue;

                sqlBuilder.Append("INSERT INTO public.\"LearnerGroups\"(\"Id\", \"Name\", \"CourseId\") VALUES");
                sqlBuilder.AppendLine();
                sqlBuilder.Append("\t(" + group.Id + ", '" + group.Name + "', " + course.Id + ");");
                sqlBuilder.AppendLine().AppendLine();

                BuildInstructorMemberships(group, enrollmentContent.Instructors);
                BuildLearnerMemberships(enrollmentContent.LearnerGroups.Find(g => g.Name.Equals(group.Name)), learners, group.Id);
            }

            return sqlBuilder.ToString();
        }

        private static void BuildInstructorMemberships(InstructorGroupColumns group, List<InstructorColumns> instructors)
        {
            var sqlBuilder = new StringBuilder();

            var startingId = group.Id * 100;
            foreach (var username in group.InstructorUsernames)
            {
                var instructor = instructors.Find(i => i.Username.Equals(username));
                if (instructor == null) continue;

                sqlBuilder.Append("INSERT INTO public.\"InstructorLearnerGroup\"(\"Id\", \"GroupsId\", \"InstructorsId\") VALUES");
                sqlBuilder.AppendLine();
                sqlBuilder.Append("\t(" + startingId++ + ", " + group.Id + ", " + instructor.Id + ");");
                sqlBuilder.AppendLine().AppendLine();
            }
        }

        private static void BuildLearnerMemberships(LearnerGroupColumns learnerGroup, List<UserLearnerColumns> learners, int groupId)
        {
            var sqlBuilder = new StringBuilder();
            if (learnerGroup == null) return;

            var startingId = groupId * 100;
            foreach (var learnerIndex in learnerGroup.LearnerIndexes)
            {
                var learner = learners.Find(l => l.Index.Equals(ExtractIndex(learnerIndex)));
                if (learner == null) continue;

                sqlBuilder.Append("INSERT INTO public.\"GroupMemberships\"(\"Id\", \"LearnerId\", \"LearnerGroupId\") VALUES");
                sqlBuilder.AppendLine();
                sqlBuilder.Append("\t(" + startingId++ + ", " + learner.Id + ", " + groupId + ");");
                sqlBuilder.AppendLine().AppendLine();
            }
        }

        private static string ExtractIndex(string text)
        {
            var program = text.Split()[0];
            var parts = text.Split()[1].Split('/');

            return program + "-" + parts[0] + "-" + parts[1];
        }

        private static string BuildMasteries(EnrollmentExcelContent enrollmentContent, DomainExcelContent domainContent, List<UserLearnerColumns> learners)
        {
            var sqlBuilder = new StringBuilder();
            var enrollmentId = -10000;
            var kcMasteryId = -10000;
            var aiMasteryId = -100000;
            foreach (var learnerId in learners.Select(l => l.Id))
            {
                foreach (var unit in domainContent.Units)
                {
                    sqlBuilder.Append(
                        "INSERT INTO public.\"UnitEnrollments\"(\"Id\", \"LearnerId\", \"KnowledgeUnitId\", \"Start\", \"Status\") VALUES");
                    sqlBuilder.AppendLine();
                    sqlBuilder.Append("\t(" + ++enrollmentId + ", " + learnerId + ", "
                                      + unit.Id + ", '" + DateTime.Now + "', " + 0 + ");");
                    sqlBuilder.AppendLine().AppendLine();
                }

                foreach (var kcId in domainContent.KnowledgeComponents.Select(kc => kc.Id))
                {
                    sqlBuilder.Append(
                        "INSERT INTO public.\"KcMasteries\"(\"Id\", \"Mastery\", \"KnowledgeComponentId\", \"LearnerId\", \"IsStarted\", \"IsPassed\", \"IsSatisfied\", \"IsCompleted\") VALUES");
                    sqlBuilder.AppendLine();
                    sqlBuilder.Append("\t(" + ++kcMasteryId + ", 0.00, " + kcId + ", "
                                       + learnerId + ", false, false, false, false);");
                    sqlBuilder.AppendLine().AppendLine();

                    var assessmentItems = domainContent.AssessmentItems.Where(ai => ai.KnowledgeComponentId == kcId)
                        .OrderBy(ai => ai.Order);
                    foreach (var item in assessmentItems)
                    {
                        sqlBuilder.Append(
                            "INSERT INTO public.\"AssessmentItemMasteries\"(\"Id\", \"AssessmentItemId\", \"Mastery\", \"SubmissionCount\", \"LastSubmissionTime\", \"KnowledgeComponentMasteryId\") VALUES");
                        sqlBuilder.AppendLine();
                        sqlBuilder.Append("\t(" + aiMasteryId++ + ", " + item.Id
                                           + ", 0.00, 0, NULL, "
                                           + kcMasteryId + ");");
                        sqlBuilder.AppendLine().AppendLine();
                    }
                }
            }

            return sqlBuilder.ToString();
        }
    }
}