using System.IO;

namespace Tutor.Web.Tests.TestData
{
    internal class ChallengeTestData
    {
        public static string[] GetFailingAchievement()
        {
	        return GetCode("FailingAchievement.txt");
        }

        public static string[] GetPassingAchievement()
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
    }
}
