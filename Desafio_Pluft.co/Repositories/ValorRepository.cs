using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio_Pluft.co.Domains;
using Desafio_Pluft.co.Interfaces;

namespace Desafio_Pluft.co.Repositories
{
    public class ValorRepository : IValorRepository
    {
        public void Cadastrar(Valores valor)
        {
            using (PluftContext ctx = new PluftContext())
            {
                ctx.Valores.Add(valor);
                ctx.SaveChanges();
            }
        }

        public void Atualizar(Valores valor)
        {
            using (PluftContext ctx = new PluftContext())
            {
                Valores novoValor = new Valores();

                novoValor.Id = valor.Id;
                novoValor.Valor = valor.Valor;
                ctx.Valores.Update(valor);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            using (PluftContext ctx = new PluftContext())
            {
                Valores valor = ctx.Valores.Find(id);

                ctx.Valores.Remove(valor);
                ctx.SaveChanges();
            }
        }

        public List<Valores> Listar()
        {
            using (PluftContext ctx = new PluftContext())
            {
                return ctx.Valores.ToList();
            }
        }
    }
}
