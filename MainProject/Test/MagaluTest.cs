namespace MainProject
{
    class MagaluTest : MagaluPage
    {
        [Test]
        public void ValidarPesquisa()
        {
            LogHeader();

            Pesquisa();
            ClicarBtnBuscar();
            ValidarProduto();
            ClicarProduto();
            AddCart();
            ValidarCarrinho();
        }
    }
}
