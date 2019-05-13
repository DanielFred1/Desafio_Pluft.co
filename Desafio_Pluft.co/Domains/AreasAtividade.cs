using System;
using System.Collections.Generic;

namespace Desafio_Pluft.co.Domains
{
    public partial class AreasAtividade
    {
        public AreasAtividade()
        {
            Instituicoes = new HashSet<Instituicoes>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<Instituicoes> Instituicoes { get; set; }
    }
}
