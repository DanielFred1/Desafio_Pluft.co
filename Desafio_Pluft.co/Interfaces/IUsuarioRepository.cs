using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio_Pluft.co.Domains;

namespace Desafio_Pluft.co.Interfaces
{
    interface IUsuarioRepository
    {
        void Cadastrar(Usuarios usuario);

        void Atualizar(Usuarios usuario);

        void Deletar(int id);

        List<Usuarios> Listar();
    }
}
