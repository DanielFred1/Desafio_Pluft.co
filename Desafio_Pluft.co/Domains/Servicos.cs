using System;
using System.Collections.Generic;

namespace Desafio_Pluft.co.Domains
{
    public partial class Servicos
    {
        public Servicos()
        {
            Agendamentos = new HashSet<Agendamentos>();
        }

        public int Id { get; set; }
        public string NomeServico { get; set; }
        public string Descricao { get; set; }
        public int IdValores { get; set; }
        public int IdCapacidades { get; set; }

        public Capacidades IdCapacidadesNavigation { get; set; }
        public Valores IdValoresNavigation { get; set; }
        public ICollection<Agendamentos> Agendamentos { get; set; }
    }
}
