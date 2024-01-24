using OpenQA.Selenium.Interactions;

namespace MainProject
{
    class MagaluPage : PageObjects
    {
        public void LogHeader() =>
            Log("<b>TESTE:</b> Valida consulta de um produto<br>" +
                "<b>====================</b><br>");

        public void Pesquisa()
        {
            var produto = "Smart TV 32” HD LED Semp R6500 Wi-Fi";
            EscreverTexto("//*[@id=\'input-search\']", produto, $"campo produto: {produto}");
        }

        public void ClicarBtnBuscar()
        {
            var text = "Buscar";
            ClicarElemento($"//*[@data-testid='search-submit']", $"botão {text}");
        }

        public void ValidarProduto()
        {
            var text = "Smart TV 32” HD LED Semp R6500 Wi-Fi";
            ValidarDados("//*[@id='__next']/div/main/section[4]/div[4]/div/ul/li[1]/a/div[3]/h2", text, $"Produto {text}");
        }

        public void ClicarProduto()
        {
            var text = "Produto";
            ClicarElemento($"//*[@id='__next']/div/main/section[4]/div[4]/div/ul/li[1]/a/div[3]/h2", $"{text}");
        }

        public void AddCart()
        {
            var text = "Compre Agora";
            ClicarElemento($"//*[@id='__next']/div/main/section[5]/div[7]/div[1]/button", $"{text}");
        }

        public void ValidarCarrinho()
        {
            var text = "Smart TV 32” HD LED Semp R6500 Wi-Fi";
            ValidarDados("//*[@id='__next']/div/main/section[2]/div[1]/div/div/p", text, $"Produto {text} no carrinho");
        }
    }
}