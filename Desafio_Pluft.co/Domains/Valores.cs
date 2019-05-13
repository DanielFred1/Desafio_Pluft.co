using System;
using System.Collections.Generic;

namespace Desafio_Pluft.co.Domains
{
    public partial class Valores
    {
        public Valores()
        {
            Servicos = new HashSet<Servicos>();
        }

        public int Id { get; set; }
        public string Valor { get; set; }

        public ICollection<Servicos> Servicos { get; set; }
    }
}
