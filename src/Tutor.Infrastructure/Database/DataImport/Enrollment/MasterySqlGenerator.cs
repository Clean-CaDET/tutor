using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tutor.Infrastructure.Database.DataImport.Domain.DomainExcelModel;
using Tutor.Infrastructure.Database.DataImport.Enrollment.EnrollmentExcelModel;
using Tutor.Infrastructure.Database.DataImport.Learner;

namespace Tutor.Infrastructure.Database.DataImport.Enrollment;

internal static class MasterySqlGenerator
{
    public static string BuildMasteries(EnrollmentExcelContent enrollmentContent, DomainExcelContent domainContent, List<UserLearnerColumns> learners)
    {
        var enrollmentId = -9473;
        var kcMasteryId = -7557;
        var aiMasteryId = -86850;

        var sqlBuilder = new StringBuilder();
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