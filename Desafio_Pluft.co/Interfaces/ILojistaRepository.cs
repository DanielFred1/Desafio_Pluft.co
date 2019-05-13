using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio_Pluft.co.Domains;

namespace Desafio_Pluft.co.Interfaces
{
    interface ILojistaRepository
    {
        void Cadastrar(Lojistas lojista);

        void Atualizar(Lojistas lojista);

        void Deletar(int id);

        List<Lojistas> Listar();
    }
}
