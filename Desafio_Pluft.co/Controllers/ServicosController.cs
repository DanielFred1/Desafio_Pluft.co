using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Desafio_Pluft.co.Domains;
using Desafio_Pluft.co.Interfaces;
using Desafio_Pluft.co.Repositories;

namespace Desafio_Pluft.co.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ServicosController : ControllerBase
    {
        private IServicoRepository ServicoRepositorio { get; set; }

        public ServicosController()
        {
            ServicoRepositorio = new ServicoRepository();
        }

        [HttpPost("cadastrar")]
        public IActionResult Cadastrar(Servicos servico)
        {
            try
            {
                ServicoRepositorio.Cadastrar(servico);
                return Ok("Serviço cadastrado com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro, não foi possível cadastrar serviço.");
            }
        }

        [HttpPut("atualizar")]
        public IActionResult Atualizar(Servicos servico)
        {
            try
            {
                ServicoRepositorio.Atualizar(servico);
                return Ok("Serviço atualizado com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro, não foi possivel atualizar serviço.");
            }
        }

        [HttpDelete("deletar/{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                ServicoRepositorio.Deletar(id);
                return Ok("Serviço removido do sistema.");
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro, não foi possível remover serviço do sistema.");
            }
        }

        [HttpGet("listar")]
        public IActionResult Listar()
        {
            try
            {
                return Ok(ServicoRepositorio.Listar());
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro, não foi possível listar serviços.");
            }
        }
    }
}