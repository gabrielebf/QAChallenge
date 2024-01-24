namespace QAChallenge.Core
{
    public class GlobalVariables
    {
        public IWebDriver driver;

        public bool driverQuit = true;

        public bool headless = false;

        public bool testPassed = true;

        public string downloadsPath = Environment.GetEnvironmentVariable("USERPROFILE") + @"\Downloads\";

    }
}
