using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio_Pluft.co.Domains;
using Desafio_Pluft.co.Interfaces;

namespace Desafio_Pluft.co.Repositories
{
    public class LogradouroRepository : ILogradouroRepository
    {
        public void Cadastrar(Logradouros logradouro)
        {
            using (PluftContext ctx = new PluftContext())
            {
                ctx.Logradouros.Add(logradouro);
                ctx.SaveChanges();
            }
        }

        public void Atualizar(Logradouros logradouro)
        {
            using (PluftContext ctx = new PluftContext())
            {
                Logradouros atualizaLogradouro = new Logradouros();

                atualizaLogradouro.Id = logradouro.Id;
                atualizaLogradouro.Rua = logradouro.Rua;
                atualizaLogradouro.Bairro = logradouro.Bairro;
                atualizaLogradouro.Cep = logradouro.Cep;
                atualizaLogradouro.Municipio = logradouro.Municipio;
                atualizaLogradouro.Estado = logradouro.Estado;
                atualizaLogradouro.Lojistas = logradouro.Lojistas;
                atualizaLogradouro.Instituicoes = logradouro.Instituicoes;

                ctx.Logradouros.Update(logradouro);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            using (PluftContext ctx = new PluftContext())
            {
                Logradouros logradouro = ctx.Logradouros.Find(id);
                ctx.Logradouros.Remove(logradouro);
                ctx.SaveChanges();
            }
        }

        public List<Logradouros> Listar()
        {
            using (PluftContext ctx = new PluftContext())
            {
                return ctx.Logradouros.ToList();
            }
        }
    }
}
