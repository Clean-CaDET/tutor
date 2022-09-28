using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tutor.Infrastructure.Database.DataImport.Domain.DomainExcelModel;
using Tutor.Infrastructure.Database.DataImport.Enrollment.EnrollmentExcelModel;
using Tutor.Infrastructure.Database.DataImport.Learner;

namespace Tutor.Infrastructure.Database.DataImport.Enrollment
{
    internal static class EnrollmentToSqlTransformer
    {
        public static string Transform(EnrollmentExcelContent enrollmentContent, DomainExcelContent domainContent, List<UserLearnerColumns> learners)
        {
            var sqlBuilder = new StringBuilder();
            sqlBuilder.Append(BuildInstructorsSql(enrollmentContent.Instructors));
            sqlBuilder.Append(BuildCourseOwnershipSql(enrollmentContent.Instructors, enrollmentContent.CourseOwnership, domainContent.Courses));
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

        private static string BuildCourseOwnershipSql(List<InstructorColumns> instructors, List<CourseOwnershipColumns> courseOwnership, List<CourseColumns> courses)
        {
            var sqlBuilder = new StringBuilder();
            sqlBuilder.AppendLine().AppendLine();
            foreach (var ownership in courseOwnership)
            {
                var course = courses.Find(c => c.Code.Equals(ownership.CourseCode));
                if (course == null) continue;

                var instructor = instructors.Find(i => i.Username.Equals(ownership.InstructorUsername));
                if (instructor == null) continue;

                sqlBuilder.Append("INSERT INTO public.\"CourseOwnerships\"(\"Id\", \"CourseId\", \"InstructorId\") VALUES");
                sqlBuilder.AppendLine();
                sqlBuilder.Append("\t(" + ownership.Id + ", " + course.Id + ", " + instructor.Id + ");");
                sqlBuilder.AppendLine().AppendLine();
            }

            return sqlBuilder.ToString();
        }

        private static string BuildLearnerGroupsSql(EnrollmentExcelContent enrollmentContent, List<CourseColumns> courses, List<UserLearnerColumns> learners)
        {
            var startingMembershipId = -100000;
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

                foreach (var username in group.InstructorUsernames)
                {
                    var instructor = enrollmentContent.Instructors.Find(i => i.Username.Equals(username));
                    if (instructor == null) continue;

                    sqlBuilder.Append("INSERT INTO public.\"GroupMemberships\"(\"Id\", \"LearnerGroupId\", \"InstructorId\", \"Role\") VALUES");
                    sqlBuilder.AppendLine();
                    sqlBuilder.Append("\t(" + startingMembershipId++ + ", " + group.Id + ", " + instructor.Id + ", 1);");
                    sqlBuilder.AppendLine().AppendLine();
                }

                var learnerGroup = enrollmentContent.LearnerGroups.Find(g => g.Name.Equals(group.Name));
                if (learnerGroup == null) continue;

                foreach (var learnerIndex in learnerGroup.LearnerIndexes)
                {
                    var learner = learners.Find(l => l.Index.Equals(learnerIndex));
                    if (learner == null) continue;

                    sqlBuilder.Append("INSERT INTO public.\"GroupMemberships\"(\"Id\", \"LearnerGroupId\", \"LearnerId\", \"Role\") VALUES");
                    sqlBuilder.AppendLine();
                    sqlBuilder.Append("\t(" + startingMembershipId++ + ", " + group.Id + ", " + learner.Id + ", 0);");
                    sqlBuilder.AppendLine().AppendLine();
                }
            }

            return sqlBuilder.ToString();
        }

        private static string BuildMasteries(EnrollmentExcelContent enrollmentContent, DomainExcelContent domainContent, List<UserLearnerColumns> learners)
        {
            var sqlBuilder = new StringBuilder();
            var enrollmentId = -10000;
            var kcMasteryId = -10000;
            var aiMasteryId = -100000;
            foreach (var learner in learners)
            {
                var enrolledUnitIds = GetEnrolledUnitIds(enrollmentContent, domainContent, learner.Index);
                var unitIds = domainContent.Units.Where(unit => enrolledUnitIds.Contains(unit.Id)).Select(unit => unit.Id);
                foreach (var unitId in unitIds)
                {
                    sqlBuilder.Append(
                        "INSERT INTO public.\"UnitEnrollments\"(\"Id\", \"LearnerId\", \"KnowledgeUnitId\", \"Start\", \"Status\") VALUES");
                    sqlBuilder.AppendLine();
                    sqlBuilder.Append("\t(" + ++enrollmentId + ", " + learner.Id + ", "
                                      + unitId + ", '" + DateTime.Now + "', " + 0 + ");");
                    sqlBuilder.AppendLine().AppendLine();

                    foreach (var kcId in domainContent.KnowledgeComponents.Where(kc => kc.UnitId == unitId).Select(kc => kc.Id))
                    {
                        sqlBuilder.Append(
                            "INSERT INTO public.\"KcMasteries\"(\"Id\", \"Mastery\", \"KnowledgeComponentId\", \"LearnerId\", \"IsStarted\", \"IsPassed\", \"IsSatisfied\", \"IsCompleted\") VALUES");
                        sqlBuilder.AppendLine();
                        sqlBuilder.Append("\t(" + ++kcMasteryId + ", 0.00, " + kcId + ", "
                                          + learner.Id + ", false, false, false, false);");
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
            }

            return sqlBuilder.ToString();
        }

        private static List<int> GetEnrolledUnitIds(EnrollmentExcelContent enrollmentContent, DomainExcelContent domainContent, string learnerIndex)
        {
            var joinedGroups = enrollmentContent.LearnerGroups.Where(g => g.LearnerIndexes.Contains(learnerIndex)).Select(g => g.Name);
            var joinedCourses = enrollmentContent.CourseGroups.Where(g => joinedGroups.Contains(g.Name)).Select(g => g.CourseCode);
            var courseIds = domainContent.Courses.Where(c => joinedCourses.Contains(c.Code)).Select(c => c.Id);
            return domainContent.Units.Where(u => courseIds.Contains(u.CourseId)).Select(u => u.Id).ToList();
        }
    }
}