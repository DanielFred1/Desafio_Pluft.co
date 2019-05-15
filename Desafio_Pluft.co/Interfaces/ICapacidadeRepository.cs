using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio_Pluft.co.Domains;

namespace Desafio_Pluft.co.Interfaces
{
    interface ICapacidadeRepository
    {
        void Cadastrar(Capacidades capacidade);

        void Atualizar(Capacidades capacidade);

        void Deletar(int id);

        List<Capacidades> Listar();
    }
}
