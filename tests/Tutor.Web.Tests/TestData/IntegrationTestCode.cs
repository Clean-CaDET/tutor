using System.IO;

namespace Tutor.Web.Tests.TestData
{
    internal class IntegrationTestCode
    {
        internal static string[] GetFailingAchievement()
        {
	        return GetCode("FailingAchievement.txt");
        }

        internal static string[] GetPassingAchievement()
        {
	        return GetCode("PassingAchievement.txt");
        }

        private static string[] GetCode(string path)
        {
	        return new[]
	        {
                File.ReadAllText("../../../TestData/" + path)
            };
        }

        internal static string[] GetFailingCourse()
        {
            return GetCode("FailingCourse.txt");
        }

        internal static string[] GetPassingCourse()
        {
            return GetCode("PassingCourse.txt");
        }
    }
}
