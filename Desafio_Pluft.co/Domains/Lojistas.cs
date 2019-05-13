using System;
using System.Collections.Generic;

namespace Desafio_Pluft.co.Domains
{
    public partial class Lojistas
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
        public int? IdTipoUsuario { get; set; }
        public int? IdInstituicao { get; set; }
        public int? IdLogradouro { get; set; }

        public Instituicoes IdInstituicaoNavigation { get; set; }
        public Logradouros IdLogradouroNavigation { get; set; }
        public TipoUsuarios IdTipoUsuarioNavigation { get; set; }
    }
}
