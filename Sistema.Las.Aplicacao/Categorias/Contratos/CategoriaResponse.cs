using System;

namespace Sistema.Las.Aplicacao.Contratos
{
    public class CategoriaResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public CategoriaResponse (Guid id, string nome, string descricao)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
        }
    }
}
