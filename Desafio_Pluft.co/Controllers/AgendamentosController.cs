using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Desafio_Pluft.co.Domains;
using Desafio_Pluft.co.Interfaces;
using Desafio_Pluft.co.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace Desafio_Pluft.co.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AgendamentosController : ControllerBase
    {
        private IAgendamentoRepository AgendamentoRepositorio { get; set; }

        public AgendamentosController()
        {
            AgendamentoRepositorio = new AgendamentoRepository();
        }

        [Authorize(Roles = "1, 2, 3")]
        [HttpPost("cadastrar")]
        public IActionResult Cadastrar(Agendamentos agendamento)
        {
            try
            {
                AgendamentoRepositorio.Cadastrar(agendamento);
                return Ok("Agendamento cadastrado com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro, não foi possível cadastrar agendamento");
            }
        }

        [Authorize(Roles = "1, 2, 3")]
        [HttpPut("atualizar")]
        public IActionResult Atualizar(Agendamentos agendamento)
        {
            try
            {
                AgendamentoRepositorio.Atualizar(agendamento);
                return Ok("Informações atualizadas com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro, não foi possível atualizar informações.");
            }
        }

        [Authorize(Roles = "1")]
        [HttpDelete("deletar/{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                AgendamentoRepositorio.Deletar(id);
                return Ok("Agendamento removido com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro, não foi possível remover agendamento do sistema.");
            }
        }

        [Authorize(Roles = "1, 2, 3")]
        [HttpGet("listar")]
        public IActionResult Listar()
        {
            try
            {
                return Ok(AgendamentoRepositorio.Listar());
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro, não foi possível encontrar lista de agendamentos.");
            }
        }
    }
}