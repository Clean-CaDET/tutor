using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using Tutor.Infrastructure.Database.DataImport.Enrollment.EnrollmentExcelModel;
using Tutor.Infrastructure.Security.Authentication.Users;

namespace Tutor.Infrastructure.Database.DataImport.Enrollment
{
    internal static class ExcelToEnrollmentTransformer
    {
        public static EnrollmentExcelContent Transform(List<ExcelWorksheet> sheets)
        {
            var instructors = CreateInstructors(sheets.Where(s => s.Name == "Instructors"));
            var courseOwnerships = CreateCourseOwnerships(sheets.Where(s => s.Name == "CourseOwnership"));
            var instructorGroups = CreateInstructorGroups(sheets.Where(s => s.Name == "InstructorGroups"));
            var learnerGroups = CreateLearnerGroups(sheets.Where(s => s.Name == "LearnerGroups"));

            return new EnrollmentExcelContent
            {
                Instructors = instructors,
                CourseOwnerships = courseOwnerships,
                CourseGroups = instructorGroups,
                LearnerGroups = learnerGroups,
            };
        }

        private static List<InstructorColumns> CreateInstructors(IEnumerable<ExcelWorksheet> sheets)
        {
            var startingId = -30000;
            var instructors = new List<InstructorColumns>();
            foreach (var sheet in sheets)
            {
                for (var row = 2; row <= sheet.Dimension.End.Row; row++)
                {
                    if (string.IsNullOrEmpty(sheet.Cells["A" + row].Text)) break;
                    var salt = PasswordUtilities.GenerateSalt();
                    instructors.Add(new InstructorColumns()
                    {
                        Id = startingId++,
                        Name = sheet.Cells["A" + row].Text,
                        Surname = sheet.Cells["B" + row].Text,
                        Username = sheet.Cells["C" + row].Text,
                        Password = PasswordUtilities.HashPassword(sheet.Cells["D" + row].Text, salt),
                        Salt = Convert.ToBase64String(salt)
                    });
                }
            }

            return instructors;
        }

        private static List<CourseOwnershipColumns> CreateCourseOwnerships(IEnumerable<ExcelWorksheet> sheets)
        {
            var startingId = -10000;
            var ownerships = new List<CourseOwnershipColumns>();
            foreach (var sheet in sheets)
            {
                for (var row = 2; row <= sheet.Dimension.End.Row; row++)
                {
                    if (string.IsNullOrEmpty(sheet.Cells["A" + row].Text)) break;
                    ownerships.Add(new CourseOwnershipColumns()
                    {
                        Id = startingId++,
                        InstructorUsername = sheet.Cells["A" + row].Text,
                        CourseCode = sheet.Cells["B" + row].Text
                    });
                }
            }

            return ownerships;
        }

        private static List<InstructorGroupColumns> CreateInstructorGroups(IEnumerable<ExcelWorksheet> sheets)
        {
            var startingId = -10000;
            var groupColumns = new List<InstructorGroupColumns>();
            foreach (var sheet in sheets)
            {
                for (var row = 2; row <= sheet.Dimension.End.Row; row++)
                {
                    var groupName = sheet.Cells["A" + row].Text;
                    if (string.IsNullOrEmpty(groupName)) break;

                    var existingGroup = groupColumns.Find(g => g.Name.Equals(groupName));
                    if (existingGroup == null)
                    {
                        groupColumns.Add(new InstructorGroupColumns()
                        {
                            Id = startingId++,
                            Name = groupName,
                            CourseCode = sheet.Cells["B" + row].Text,
                            InstructorUsernames = new HashSet<string> { sheet.Cells["C" + row].Text }
                        });
                    }
                    else
                    {
                        existingGroup.InstructorUsernames.Add(sheet.Cells["C" + row].Text);
                    }
                }
            }

            return groupColumns;
        }

        private static List<LearnerGroupColumns> CreateLearnerGroups(IEnumerable<ExcelWorksheet> sheets)
        {
            var startingId = -10000;
            var groupColumns = new List<LearnerGroupColumns>();
            foreach (var sheet in sheets)
            {
                for (var row = 2; row <= sheet.Dimension.End.Row; row++)
                {
                    var groupName = sheet.Cells["A" + row].Text;
                    if (string.IsNullOrEmpty(groupName)) break;

                    var existingGroup = groupColumns.Find(g => g.Name.Equals(groupName));
                    if (existingGroup == null)
                    {
                        groupColumns.Add(new LearnerGroupColumns()
                        {
                            Id = startingId++,
                            Name = groupName,
                            LearnerIndexes = new HashSet<string> { sheet.Cells["B" + row].Text }
                        });
                    }
                    else
                    {
                        existingGroup.LearnerIndexes.Add(sheet.Cells["B" + row].Text);
                    }
                }
            }

            return groupColumns;
        }
    }
}