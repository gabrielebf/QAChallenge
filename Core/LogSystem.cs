using System.Text;
namespace QAChallenge.Core
{
    public class LogSystem : GlobalVariables
    {
        #region Variables

        string fileName, filePath, logResult;
        public StringBuilder log = new();
        public string sysMsgErr = "</b><p><font color = black><b>System Message Error: </b><i>";
        readonly string testOk = "<p><b>=============<br>FIM DO TESTE – OK!";
        readonly string testNok = "</i><p><font color = black><b>==============<br>FIM DO TESTE – <font color = red>NOK!<p align=center>";

        #endregion

        #region Log Function

        public void Log(string text)
        {
            if (testPassed) log.Append(text + "<br>");
            else log.Append("<font color = red><b>" + text);
        }

        #endregion

        #region SaveLog Function

        public void SaveLog()
        {
            string folderDate = DateTime.Now.ToString("yyyy-MM-dd");
            filePath = $@"C:\BeesQA\BeesQA\Logs\Log{folderDate}\";
            if (!Directory.Exists(filePath)) Directory.CreateDirectory(filePath);
            fileName = GetType().Name; string file = $"{filePath}{fileName}.html";

            string htmlStart = "<html><body><p><font face = Verdana size = 2>";
            string htmlEnd = "</p></font></body></html>";
            string header = "<b>ACESSO AO SISTEMA<br>==============</b><br>"
                + "Abriu o navegador e acessou o site da <b>MagazineLuiza</b><p>";

            Screenshot imgCaptured = ((ITakesScreenshot)driver).GetScreenshot();
            string image = $"<img src='data:/image/png;base64, {imgCaptured} 'width='972' height='435'/>";

            StreamWriter sw = new(file);
            if (!testPassed) logResult = $"{htmlStart}{header}{log}{testNok}{image}{htmlEnd}";
            else logResult = $"{htmlStart}{header}{log}{testOk}{htmlEnd}";
            sw.Write(logResult); sw.Close(); testPassed = true;
        }

        #endregion
    }
}
