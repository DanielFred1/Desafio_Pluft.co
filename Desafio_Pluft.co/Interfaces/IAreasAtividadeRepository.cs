using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio_Pluft.co.Domains;

namespace Desafio_Pluft.co.Interfaces
{
    interface IAreasAtividadeRepository
    {
        void Cadastrar(AreasAtividade area);

        void Atualizar(AreasAtividade area);

        void Deletar(int id);

        List<AreasAtividade> Listar();
    }
}
