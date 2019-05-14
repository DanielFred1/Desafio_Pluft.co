using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio_Pluft.co.Domains;
using Desafio_Pluft.co.Interfaces;

namespace Desafio_Pluft.co.Repositories
{
    public class ServicoRepository : IServicoRepository
    {
        public void Cadastrar(Servicos servico)
        {
            using (PluftContext ctx = new PluftContext())
            {
                ctx.Servicos.Add(servico);
                ctx.SaveChanges();
            }
        }

        public void Atualizar(Servicos servico)
        {
            using (PluftContext ctx = new PluftContext())
            {
                Servicos atualizaServico = new Servicos();

                atualizaServico.Id = servico.Id;
                atualizaServico.NomeServico = servico.NomeServico;
                atualizaServico.Descricao = servico.Descricao;
                atualizaServico.IdCapacidades = servico.IdCapacidades;
                atualizaServico.IdValores = servico.IdValores;

                ctx.Servicos.Update(servico);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            using (PluftContext ctx = new PluftContext())
            {
                Servicos servico = ctx.Servicos.Find(id);

                ctx.Servicos.Remove(servico);
                ctx.SaveChanges();
            }
        }

        public List<Servicos> Listar()
        {
            using (PluftContext ctx = new PluftContext())
            {
                return ctx.Servicos.ToList();
            }
        }
    }
}
