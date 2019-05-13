using System;
using System.Collections.Generic;

namespace Desafio_Pluft.co.Domains
{
    public partial class Instituicoes
    {
        public Instituicoes()
        {
            Agendamentos = new HashSet<Agendamentos>();
            Lojistas = new HashSet<Lojistas>();
        }

        public int Id { get; set; }
        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
        public string Telefone { get; set; }
        public int IdAreasAtividade { get; set; }
        public int IdLogradouro { get; set; }

        public AreasAtividade IdAreasAtividadeNavigation { get; set; }
        public Logradouros IdLogradouroNavigation { get; set; }
        public ICollection<Agendamentos> Agendamentos { get; set; }
        public ICollection<Lojistas> Lojistas { get; set; }
    }
}
