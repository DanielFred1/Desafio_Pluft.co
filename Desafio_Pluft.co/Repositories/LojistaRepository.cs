using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio_Pluft.co.Domains;
using Desafio_Pluft.co.Interfaces;

namespace Desafio_Pluft.co.Repositories
{
    public class LojistaRepository : ILojistaRepository
    {
        public void Cadastrar(Lojistas lojista)
        {
            using (PluftContext ctx = new PluftContext())
            {
                ctx.Lojistas.Add(lojista);
                ctx.SaveChanges();
            }
        }

        public void Atualizar(Lojistas lojista)
        {
            using (PluftContext ctx = new PluftContext())
            {
                Lojistas atualizaLojista = new Lojistas();

                atualizaLojista.Nome = lojista.Nome;
                atualizaLojista.Rg = lojista.Rg;
                atualizaLojista.Cpf = lojista.Cpf;
                atualizaLojista.Email = lojista.Email;
                atualizaLojista.Senha = lojista.Senha;
                atualizaLojista.Telefone = lojista.Telefone;
                atualizaLojista.IdLogradouro = lojista.IdLogradouro;

                ctx.Lojistas.Update(lojista);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            using (PluftContext ctx = new PluftContext())
            {
                Lojistas lojista = ctx.Lojistas.Find(id);

                ctx.Lojistas.Remove(lojista);
                ctx.SaveChanges();
            }
        }

        public List<Lojistas> Listar()
        {
            using (PluftContext ctx = new PluftContext())
            {
                return ctx.Lojistas.ToList();
            }
        }
    }
}
