using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio_Pluft.co.Domains;

namespace Desafio_Pluft.co.Interfaces
{
    interface IServicoRepository
    {
        void Cadastrar(Servicos servico);

        void Atualizar(Servicos servico);

        void Deletar(int id);

        List<Servicos> Listar();
    }
}
