using System;
using System.Collections.Generic;

namespace Desafio_Pluft.co.Domains
{
    public partial class Logradouros
    {
        public Logradouros()
        {
            Instituicoes = new HashSet<Instituicoes>();
            Lojistas = new HashSet<Lojistas>();
            Usuarios = new HashSet<Usuarios>();
        }

        public int Id { get; set; }
        public string Rua { get; set; }
        public string Cep { get; set; }
        public string Bairro { get; set; }
        public string Municipio { get; set; }
        public string Estado { get; set; }

        public ICollection<Instituicoes> Instituicoes { get; set; }
        public ICollection<Lojistas> Lojistas { get; set; }
        public ICollection<Usuarios> Usuarios { get; set; }
    }
}
