using System.IO;

namespace Tutor.Web.Tests.TestData
{
    internal static class ChallengeSubmissionTestCode
    {
        internal static string[] GetFailingAchievement()
        {
	        return GetCode("FailingAchievement.txt");
        }

        internal static string[] GetPassingAchievement()
        {
	        return GetCode("PassingAchievement.txt");
        }

        internal static string[] GetFailingCourse()
        {
            return GetCode("FailingCourse.txt");
        }

        internal static string[] GetPassingCourse()
        {
            return GetCode("PassingCourse.txt");
        }

        public static string[] GetFailingParams()
        {
            return GetCode("FailingParams.txt");
        }

        public static string[] GetPassingParams()
        {
            return GetCode("PassingParams.txt");
        }

        private static string[] GetCode(string path)
        {
	        return new[]
	        {
                File.ReadAllText("../../../TestData/ChallengeSubmissions/" + path)
            };
        }
    }
}
