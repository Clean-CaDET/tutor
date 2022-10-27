using System.Collections.Generic;
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
    }
}