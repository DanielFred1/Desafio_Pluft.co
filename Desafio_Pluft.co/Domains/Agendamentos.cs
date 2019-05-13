using System;
using System.Collections.Generic;

namespace Desafio_Pluft.co.Domains
{
    public partial class Agendamentos
    {
        public int Id { get; set; }
        public DateTime DataAgendamento { get; set; }
        public TimeSpan HoraAgendamento { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdInsituicao { get; set; }
        public int IdServico { get; set; }
        public int IdStatus { get; set; }

        public Instituicoes IdInsituicaoNavigation { get; set; }
        public Servicos IdServicoNavigation { get; set; }
        public StatusAgendamento IdStatusNavigation { get; set; }
        public Usuarios IdUsuarioNavigation { get; set; }
    }
}
