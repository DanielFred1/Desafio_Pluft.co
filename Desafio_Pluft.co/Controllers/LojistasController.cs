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
    public class LojistasController : ControllerBase
    {
        private ILojistaRepository LojistaRepositorio { get; set; }

        public LojistasController()
        {
            LojistaRepositorio = new LojistaRepository();
        }

        [Authorize(Roles = "1")]
        [HttpPost("cadastrar")]
        public IActionResult Cadastrar(Lojistas lojista)
        {
            try
            {
                LojistaRepositorio.Cadastrar(lojista);
                return Ok("Cadastro efetuado com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro, não foi possível concluir cadastro.");
            }
        }

        [Authorize(Roles = "1, 2")]
        [HttpPut("atualizar")]
        public IActionResult Atualizar(Lojistas lojista)
        {
            try
            {
                LojistaRepositorio.Atualizar(lojista);
                return Ok("Atualizado com sucesso.");
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
                LojistaRepositorio.Deletar(id);
                return Ok("Lojista removido do sistema.");
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro, não foi possível remover lojista do sistema.");
            }
        }

        [Authorize(Roles = "1")]
        [HttpGet("listar")]
        public IActionResult Listar()
        {
            try
            {
               return Ok(LojistaRepositorio.Listar());
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro, não foi possível listar lojistas.");
            }
        }
    }
}