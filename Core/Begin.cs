global using QAChallenge.Core;
global using NUnit.Framework;
global using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using System.Diagnostics;

namespace QAChallenge.Core
{
    public class Begin : DSL
    {

        #region Abre navegador
        public void AbreNavegador()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());

            var devMode = new ChromeOptions();
            devMode.AddArgument("disable-cache");
            devMode.AddArgument("start-maximized");

            var headlessMode = new ChromeOptions();
            headlessMode.AddArgument("disable-cache");
            headlessMode.AddArgument("window-size=1920x1080");
            headlessMode.AddUserProfilePreference("download.default_directory", downloadsPath);
            headlessMode.AddArgument("headless");

            if (headless) driver = new ChromeDriver(headlessMode);
            else driver = new ChromeDriver(devMode);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }
        #endregion

        #region Fecha navegador
        public void FechaNavegador()
        {
            if(driverQuit) driver.Quit();
            else
            {
                ProcessStartInfo psi = new() { FileName = "taskkill", Arguments = "/F /IM chromedriver.exe" };
                using Process process = new() { StartInfo = psi };
                process.Start(); process.WaitForExit();
            }
        }
        #endregion

        #region Funções para acesso ao sistema
        [SetUp]
        public void Start()
        {
            AbreNavegador();
            driver.Navigate().GoToUrl("https://www.magazineluiza.com.br/");
        }
        #endregion

        #region Finish
        [TearDown]
        public void Finish()
        {
            SaveLog();
            FechaNavegador();
        }
        #endregion
    }
}