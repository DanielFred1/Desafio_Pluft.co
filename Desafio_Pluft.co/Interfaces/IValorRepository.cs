using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio_Pluft.co.Domains;

namespace Desafio_Pluft.co.Interfaces
{
    interface IValorRepository
    {
        void Cadastrar(Valores valor);

        void Atualizar(Valores valor);

        void Deletar(int id);

        List<Valores> Listar();
    }
}
