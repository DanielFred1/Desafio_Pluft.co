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
    public class CapacidadesController : ControllerBase
    {
        private ICapacidadeRepository CapacidadeRepositorio { get; set; }

        public CapacidadesController()
        {
            CapacidadeRepositorio = new CapacidadeRepository();
        }

        [HttpPost("cadastrar")]
        public IActionResult Cadastrar(Capacidades capacidade)
        {
            try
            {
                CapacidadeRepositorio.Cadastrar(capacidade);
                return Ok("Capacidade cadastrada com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro, não foi possível cadastrar capacidade.");
            }
        }

        [HttpPut("atualizar")]
        public IActionResult Atualizar(Capacidades capacidade)
        {
            try
            {
                CapacidadeRepositorio.Atualizar(capacidade);
                return Ok("Informações atualizadas com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro, não foi possível atualizar informações.");
            }
        }

        [HttpDelete("deletar/{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                CapacidadeRepositorio.Deletar(id);
                return Ok("Capacidade removida do sistema.");
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro, não foi possível remover capacidade do sistema.");
            }
        }

        [HttpGet("listar")]
        public IActionResult Listar()
        {
            try
            {
                return Ok(CapacidadeRepositorio.Listar());
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro, não foi possível listar capacidades");
            }
        }
    }
}