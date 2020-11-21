namespace Sistema.Las.Api.Configuracoes.Indentity.Extensions
{
    public class IdentitySettings
    {
        public string Secret { get; set; }
        public int ExpiracaoHoras { get; set; }
        public string Emissor { get; set; }
        public string ValidoEm { get; set; }
    }
}
