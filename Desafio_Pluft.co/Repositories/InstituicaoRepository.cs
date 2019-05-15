using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio_Pluft.co.Domains;
using Desafio_Pluft.co.Interfaces;
using Desafio_Pluft.co.Repositories;

namespace Desafio_Pluft.co.Repositories
{
    public class InstituicaoRepository : IInstituicaoRepository
    {
        public void Cadastrar(Instituicoes instituicao)
        {
            using (PluftContext ctx = new PluftContext())
            {
                ctx.Instituicoes.Add(instituicao);
                ctx.SaveChanges();
            }
        }

        public void Atualizar(Instituicoes instituicao)
        {
            using (PluftContext ctx = new PluftContext())
            {
                Instituicoes atualizaInstituicao = new Instituicoes();

                atualizaInstituicao.Id = instituicao.Id;
                atualizaInstituicao.NomeFantasia = instituicao.NomeFantasia;
                atualizaInstituicao.RazaoSocial = instituicao.RazaoSocial;
                atualizaInstituicao.Cnpj = instituicao.Cnpj;
                atualizaInstituicao.Telefone = instituicao.Telefone;
                atualizaInstituicao.Lojistas = instituicao.Lojistas;
                atualizaInstituicao.IdLogradouro = instituicao.IdLogradouro;
                atualizaInstituicao.IdAreasAtividade = instituicao.IdAreasAtividade;
                atualizaInstituicao.Agendamentos = instituicao.Agendamentos;

                ctx.Instituicoes.Update(instituicao);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            using (PluftContext ctx = new PluftContext())
            {
                Instituicoes instituicao = ctx.Instituicoes.Find(id);

                ctx.Instituicoes.Remove(instituicao);
                ctx.SaveChanges();
            }
        }

        public List<Instituicoes> Listar()
        {
            using (PluftContext ctx = new PluftContext())
            {
                return ctx.Instituicoes.ToList();
            }
        }
    }
}
