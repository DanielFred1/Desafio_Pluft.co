using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio_Pluft.co.Domains;

namespace Desafio_Pluft.co.Interfaces
{
    interface IInstituicaoRepository
    {
        void Cadastrar(Instituicoes instituicao);

        void Atualizar(Instituicoes instituicao);

        void Deletar(int id);

        List<Instituicoes> Listar();
    }
}
