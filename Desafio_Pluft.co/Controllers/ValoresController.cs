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
    public class ValoresController : ControllerBase
    {
        private IValorRepository ValorRepositorio { get; set; }

        public ValoresController()
        {
            ValorRepositorio = new ValorRepository();
        }

        [HttpPost("cadastrar")]
        public IActionResult Cadastrar(Valores valor)
        {
            try
            {
                ValorRepositorio.Cadastrar(valor);
                return Ok("Valor cadastrado com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro, não foi possível cadastrar valor.");
            }
        }

        [HttpPut("atualizar")]
        public IActionResult Atualizar(Valores valor)
        {
            try
            {
                ValorRepositorio.Atualizar(valor);
                return Ok("Valor atualizado com suceso.");
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro, não foi possivel atualizar valor.");
            }
        }

        [HttpDelete("deletar/{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                ValorRepositorio.Deletar(id);
                return Ok("Valor removido do sistema.");
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro, não foi possível deletar valor.");
            }
        }

        [HttpGet("listar")]
        public IActionResult Listar()
        {
            try
            {
                return Ok(ValorRepositorio.Listar());
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro, não foi possivel listar valores.");
            }
        }
    }
}