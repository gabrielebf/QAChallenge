using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Runtime.InteropServices;

namespace QAChallenge.Core
{
    public class DSL : LogSystem
    {
        #region Funções de manipulação

        public static void Wait(int ms) => Thread.Sleep(ms);
        public void ClearData(string xpath) => driver.FindElement(By.XPath(xpath)).Clear();
        public void WaitElement(string xpath, int seconds = 90)
        {
            WebDriverWait wait = new(driver, TimeSpan.FromSeconds(seconds));
            wait.Until((d) => d.FindElement(By.XPath(xpath))); Wait(1000);
        }
        public void WaitElementGone(string xpath, int seconds = 90)
        {
            WebDriverWait wait = new(driver, TimeSpan.FromSeconds(seconds));
            wait.Until(d => d.FindElements(By.XPath(xpath)).Count == 0);
        }

        #endregion

        #region Funções de interação

        public void ClicarElemento(string xpath, [Optional] string description, int timer = 1000)
        {
            try
            {
                driver.FindElement(By.XPath(xpath)).Click(); Wait(timer);
                if (description != null) Log($"Clicou em {description}");
            }
            catch (Exception ex)
            {
                testPassed = false; var msgErr = $"Erro ao clicar em {description}";
                if (description != null) Log($"{msgErr} {sysMsgErr} {ex.Message}"); Assert.Fail(msgErr);
            }
        }
        public void EscreverTexto(string xpath, string value, [Optional] string description)
        {
            try
            {
                driver.FindElement(By.XPath(xpath)).SendKeys(value);
                if (description != null) Log($"Preencheu {description}");
            }
            catch (Exception ex)
            {
                testPassed = false; var msgErr = $"Erro ao preencher {description}";
                if (description != null) Log($"{msgErr} {sysMsgErr} {ex.Message}"); Assert.Fail(msgErr);
            }
        }
        public void ValidarDados(string xpath, string value, [Optional] string description)
        {
            try
            {
                Assert.That(driver.FindElement(By.XPath(xpath)).Text, Does.Contain(value));
                if (description != null) Log($"Validou {description}");
            }
            catch (Exception ex)
            {
                testPassed = false; var msgErr = $"Erro ao validar {description}";
                if (description != null) Log($"{msgErr} {sysMsgErr} {ex.Message}"); Assert.Fail(msgErr);
            }
        }


        #endregion

        #region Funções de simulação de teclas

        public void Tab(int ms = 100)
        {
            Actions act = new(driver);
            act.SendKeys(Keys.Tab).Perform(); Wait(ms);
        }
        public void Enter(int ms = 100)
        {
            Actions act = new(driver);
            act.SendKeys(Keys.Enter).Perform(); Wait(ms);
        }
        public void Delete(int ms = 100)
        {
            Actions act = new(driver);
            act.SendKeys(Keys.Delete).Perform(); Wait(ms);
        }
        public void PageUp(int ms = 100)
        {
            Actions act = new(driver);
            act.SendKeys(Keys.PageUp).Perform(); Wait(ms);
        }
        public void PageDown(int ms = 100)
        {
            Actions act = new(driver);
            act.SendKeys(Keys.PageDown).Perform(); Wait(ms);
        }
        public void Backspace(int ms = 100)
        {
            Actions act = new(driver);
            act.SendKeys(Keys.Backspace).Perform(); Wait(ms);
        }

        #endregion
    }
}
