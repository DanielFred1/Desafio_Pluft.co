using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio_Pluft.co.Domains;

namespace Desafio_Pluft.co.Interfaces
{
    interface ILogradouroRepository
    {
        void Cadastrar(Logradouros logradouro);

        void Atualizar(Logradouros logradouro);

        void Deletar(int id);

        List<Logradouros> Listar();
    }
}
