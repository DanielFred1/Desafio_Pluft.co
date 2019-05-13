using System;
using System.Collections.Generic;

namespace Desafio_Pluft.co.Domains
{
    public partial class Capacidades
    {
        public Capacidades()
        {
            Servicos = new HashSet<Servicos>();
        }

        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Quantidade { get; set; }

        public ICollection<Servicos> Servicos { get; set; }
    }
}
