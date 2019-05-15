using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio_Pluft.co.Domains;
using Desafio_Pluft.co.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Desafio_Pluft.co.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public void Cadastrar(Usuarios usuario)
        {
            using (PluftContext ctx = new PluftContext())
            {
                ctx.Usuarios.Add(usuario);
                ctx.SaveChanges();
            }
        }

        public void Atualizar(Usuarios usuario)
        {
            using (PluftContext ctx = new PluftContext())
            {
                Usuarios atualizaUsuario = new Usuarios();

                atualizaUsuario.Cpf = usuario.Cpf;
                atualizaUsuario.Email = usuario.Email;
                atualizaUsuario.Nome = usuario.Nome;
                atualizaUsuario.Rg = usuario.Rg;
                atualizaUsuario.Senha = usuario.Senha;
                atualizaUsuario.Telefone = usuario.Telefone;
                atualizaUsuario.IdLogradouro = usuario.IdLogradouro;

                ctx.Usuarios.Update(usuario);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            using (PluftContext ctx = new PluftContext())
            {
                Usuarios usuario = ctx.Usuarios.Find(id);

                ctx.Usuarios.Remove(usuario);
                ctx.SaveChanges();
            }
        }

        public List<Usuarios> Listar()
        {
            using (PluftContext ctx = new PluftContext())
            {
                return ctx.Usuarios.ToList();
            }
        }

        public Usuarios BuscarPorEmailESenha(string email, string senha)
        {
            using (PluftContext ctx = new PluftContext())
            {
                return ctx.Usuarios.Include(c => c.IdTipoUsuarioNavigation).FirstOrDefault(x => x.Email == email && x.Senha == senha);
            }
        }
    }
}
