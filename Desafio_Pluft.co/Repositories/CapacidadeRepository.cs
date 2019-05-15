using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio_Pluft.co.Domains;
using Desafio_Pluft.co.Interfaces;
using Desafio_Pluft.co.Repositories;

namespace Desafio_Pluft.co.Repositories
{
    public class CapacidadeRepository : ICapacidadeRepository
    {
        public void Cadastrar(Capacidades capacidade)
        {
            using (PluftContext ctx = new PluftContext())
            {
                ctx.Capacidades.Add(capacidade);
                ctx.SaveChanges();
            }
        }

        public void Atualizar(Capacidades capacidade)
        {
            using (PluftContext ctx = new PluftContext())
            {
                Capacidades atualizaCapacidade = new Capacidades();

                atualizaCapacidade.Id = capacidade.Id;
                atualizaCapacidade.Descricao = capacidade.Descricao;
                atualizaCapacidade.Quantidade = capacidade.Quantidade;
                atualizaCapacidade.Servicos = capacidade.Servicos;

                ctx.Capacidades.Update(capacidade);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            using (PluftContext ctx = new PluftContext())
            {
                Capacidades capacidade = ctx.Capacidades.Find(id);

                ctx.Capacidades.Remove(capacidade);
                ctx.SaveChanges();
            }
        }

        public List<Capacidades> Listar()
        {
            using (PluftContext ctx = new PluftContext())
            {
                return ctx.Capacidades.ToList();
            }
        }
    }
}
