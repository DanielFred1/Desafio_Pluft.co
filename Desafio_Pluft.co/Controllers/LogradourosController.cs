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
    public class LogradourosController : ControllerBase
    {
        private ILogradouroRepository LogradouroRepositorio { get; set; }

        public LogradourosController()
        {
            LogradouroRepositorio = new LogradouroRepository();
        }

        [Authorize(Roles = "1, 2, 3")]
        [HttpPost("cadastrar")]
        public IActionResult Cadastrar(Logradouros logradouro)
        {
            try
            {
                LogradouroRepositorio.Cadastrar(logradouro);
                return Ok("Endereço cadastrado com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro, não foi possível cadastrar endereço.");
            }
        }

        [Authorize(Roles = "1, 2, 3")]
        [HttpPut("atualizar")]
        public IActionResult Atualizar(Logradouros logradouro)
        {
            try
            {
                LogradouroRepositorio.Atualizar(logradouro);
                return Ok("Endereço atualizado com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro, não foi possivel atualizar informações.");
            }
        }

        [Authorize(Roles = "1")]
        [HttpDelete("deletar/{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                LogradouroRepositorio.Deletar(id);
                return Ok("Endereço removido do sistema.");
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro, não foi possível remover endereço.");
            }
        }

        [Authorize(Roles = "1, 2, 3")]
        [HttpGet("listar")]
        public IActionResult Listar()
        {
            try
            {
                return Ok(LogradouroRepositorio.Listar());
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro, não foi possível listar endereços.");
            }
        }
    }
}