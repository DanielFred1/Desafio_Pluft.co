using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio_Pluft.co.Domains;
using Desafio_Pluft.co.Interfaces;

namespace Desafio_Pluft.co.Repositories
{
    public class AreasAtividadeRepository : IAreasAtividadeRepository
    {
        public void Cadastrar(AreasAtividade area)
        {
            using (PluftContext ctx = new PluftContext())
            {
                ctx.AreasAtividade.Add(area);
                ctx.SaveChanges();
            }
        }

        public void Atualizar(AreasAtividade area)
        {
            using (PluftContext ctx = new PluftContext())
            {
                AreasAtividade novaArea = new AreasAtividade();

                novaArea.Id = area.Id;
                novaArea.Nome = area.Nome;
                novaArea.Instituicoes = area.Instituicoes;

                ctx.AreasAtividade.Update(area);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            using (PluftContext ctx = new PluftContext())
            {
                AreasAtividade area = ctx.AreasAtividade.Find(id);

                ctx.AreasAtividade.Remove(area);
                ctx.SaveChanges();
            }
        }

        public List<AreasAtividade> Listar()
        {
            using (PluftContext ctx = new PluftContext())
            {
                return ctx.AreasAtividade.ToList();
            }
        }
    }
}
