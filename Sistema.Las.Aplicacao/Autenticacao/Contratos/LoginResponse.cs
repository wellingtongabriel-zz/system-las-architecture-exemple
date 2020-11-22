using System;
using System.Collections.Generic;

namespace Sistema.Las.Aplicacao.Autenticacao.Contratos
{
    public class UsuarioResponse
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public IEnumerable<PermissoesResponse> Permissoes { get; set; }
    }


    public class LoginResponse
    {
        public string Token { get; set; }
        public double ExpiresIn { get; set; }
        public UsuarioResponse Usuario { get; set; }
    }

    public class PermissoesResponse
    {
        public string Value { get; set; }
        public string Type { get; set; }
    }
}
