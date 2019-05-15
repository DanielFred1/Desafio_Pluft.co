using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio_Pluft.co.Domains;

namespace Desafio_Pluft.co.Interfaces
{
    interface IAgendamentoRepository
    {
        void Cadastrar(Agendamentos agendamento);

        void Atualizar(Agendamentos agendamento);

        void Deletar(int id);

        List<Agendamentos> Listar();
    }
}
