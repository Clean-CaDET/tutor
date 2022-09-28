﻿using OfficeOpenXml;
using System;
using System.Collections.Generic;
using Tutor.Infrastructure.Security.Authentication.Users;

namespace Tutor.Infrastructure.Database.DataImport.Learner
{
    internal static class ExcelToLearnerTransformer
    {
        public static List<UserLearnerColumns> Transform(List<ExcelWorksheet> sheets)
        {
            var startingId = -10000;
            var learners = new List<UserLearnerColumns>();
            foreach (var sheet in sheets)
            {
                for (var row = 2; row <= sheet.Dimension.End.Row; row++)
                {
                    if (string.IsNullOrEmpty(sheet.Cells["C" + row].Text)) break;
                    var index = ExtractIndex(sheet.Cells["C" + row].Text);
                    var salt = PasswordUtilities.GenerateSalt();
                    learners.Add(new UserLearnerColumns
                    {
                        Id = startingId++,
                        Index = index,
                        Surname = sheet.Cells["D" + row].Text,
                        Name = sheet.Cells["E" + row].Text,
                        Salt = Convert.ToBase64String(salt),
                        Password = PasswordUtilities.HashPassword(sheet.Cells["F" + row].Text, salt)
                    });
                }
            }

            return learners;
        }

        private static string ExtractIndex(string text)
        {
            var program = text.Split()[0];
            var parts = text.Split()[1].Split('/');

            return program + "-" + parts[0] + "-" + parts[1];
        }
    }
}