using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using Tutor.Infrastructure.DataImport.Enrollment.EnrollmentExcelModel;
using Tutor.Infrastructure.Security.Authentication.Users;

namespace Tutor.Infrastructure.DataImport.Enrollment;

internal class ExcelToEnrollmentTransformer
{
    private int _instructorId;
    private int _courseOwnershipId;
    private int _instructorGroupId;
    private int _learningGroupId;

    public ExcelToEnrollmentTransformer()
    {
        _instructorId = -30000;
        _courseOwnershipId = -10000;
        _instructorGroupId = -10000;
        _learningGroupId = -10000;
    }

    public EnrollmentExcelContent Transform(List<ExcelWorksheet> sheets)
    {
        var instructors = CreateInstructors(sheets.Where(s => s.Name == "Instructors").ToList());
        var courseOwnerships = CreateCourseOwnerships(sheets.Where(s => s.Name == "CourseOwnership").ToList());
        var instructorGroups = CreateInstructorGroups(sheets.Where(s => s.Name == "InstructorGroups").ToList());
        var learnerGroups = CreateLearnerGroups(sheets.Where(s => s.Name == "LearnerGroups").ToList());

        return new EnrollmentExcelContent
        {
            Instructors = instructors,
            CourseOwnership = courseOwnerships,
            CourseGroups = instructorGroups,
            LearnerGroups = learnerGroups,
        };
    }

    private List<InstructorColumns> CreateInstructors(List<ExcelWorksheet> sheets)
    {
        if (sheets.Count == 0) return new List<InstructorColumns>();

        var instructors = new List<InstructorColumns>();
        foreach (var sheet in sheets)
        {
            for (var row = 2; row <= sheet.Dimension.End.Row; row++)
            {
                if (string.IsNullOrEmpty(sheet.Cells["A" + row].Text)) break;
                var salt = PasswordUtilities.GenerateSalt();
                instructors.Add(new InstructorColumns()
                {
                    Id = _instructorId++,
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

    private List<CourseOwnershipColumns> CreateCourseOwnerships(List<ExcelWorksheet> sheets)
    {
        if (sheets.Count == 0) return new List<CourseOwnershipColumns>();

        var ownerships = new List<CourseOwnershipColumns>();
        foreach (var sheet in sheets)
        {
            for (var row = 2; row <= sheet.Dimension.End.Row; row++)
            {
                if (string.IsNullOrEmpty(sheet.Cells["A" + row].Text)) break;
                ownerships.Add(new CourseOwnershipColumns()
                {
                    Id = _courseOwnershipId++,
                    InstructorUsername = sheet.Cells["A" + row].Text,
                    CourseCode = sheet.Cells["B" + row].Text
                });
            }
        }

        return ownerships;
    }

    private List<InstructorGroupColumns> CreateInstructorGroups(List<ExcelWorksheet> sheets)
    {
        if (sheets.Count == 0) return new List<InstructorGroupColumns>();

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
                        Id = _instructorGroupId++,
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

    private List<LearnerGroupColumns> CreateLearnerGroups(List<ExcelWorksheet> sheets)
    {
        if (sheets.Count == 0) return new List<LearnerGroupColumns>();

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
                        Id = _learningGroupId++,
                        Name = groupName,
                        LearnerIndexes = new HashSet<string> { ExtractIndex(sheet.Cells["B" + row].Text) }
                    });
                }
                else
                {
                    existingGroup.LearnerIndexes.Add(ExtractIndex(sheet.Cells["B" + row].Text));
                }
            }
        }

        return groupColumns;
    }

    private static string ExtractIndex(string text)
    {
        var program = text.Split()[0];
        var parts = text.Split()[1].Split('/');

        return program + "-" + parts[0] + "-" + parts[1];
    }
}