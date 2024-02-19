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
            var devMode = new ChromeOptions();
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
                if (driverQuit) driver.Quit();
                else foreach (var process in Process.GetProcessesByName("chromedriver")) process.Kill(); 
            }
        }
        #endregion

        #region Funções para acesso ao sistema
        [SetUp]
        public void Start()
        {
            try { 
                AbreNavegador(); 
                driver.Navigate().GoToUrl("https://www.magazineluiza.com.br/"); 
            }catch { new DriverManager().SetUpDriver(new ChromeDriver()); }
                
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