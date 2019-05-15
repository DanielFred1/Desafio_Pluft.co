using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio_Pluft.co.Domains;
using Desafio_Pluft.co.Interfaces;

namespace Desafio_Pluft.co.Repositories
{
    public class AgendamentoRepository : IAgendamentoRepository
    {
        public void Cadastrar(Agendamentos agendamento)
        {
            using (PluftContext ctx = new PluftContext())
            {
                ctx.Agendamentos.Add(agendamento);
                ctx.SaveChanges();
            }
        }

        public void Atualizar(Agendamentos agendamento)
        {
            using (PluftContext ctx = new PluftContext())
            {
                Agendamentos atualizaAgendamento = new Agendamentos();

                atualizaAgendamento.Id = agendamento.Id;
                atualizaAgendamento.DataAgendamento = agendamento.DataAgendamento;
                atualizaAgendamento.HoraAgendamento = agendamento.HoraAgendamento;
                atualizaAgendamento.IdServico = agendamento.IdServico;
                atualizaAgendamento.IdUsuario = agendamento.IdUsuario;
                atualizaAgendamento.IdInsituicao = agendamento.IdInsituicao;
                atualizaAgendamento.IdStatus = agendamento.IdStatus;

                ctx.Agendamentos.Update(agendamento);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            using (PluftContext ctx = new PluftContext())
            {
                Agendamentos agendamento = ctx.Agendamentos.Find(id);

                ctx.Agendamentos.Remove(agendamento);
                ctx.SaveChanges();
            }
        }

        public List<Agendamentos> Listar()
        {
            using (PluftContext ctx = new PluftContext())
            {
                return ctx.Agendamentos.ToList();
            }
        }
    }
}
