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
    public class InstituicoesController : ControllerBase
    {
        private IInstituicaoRepository InstituicaoRepositorio { get; set; }

        public InstituicoesController()
        {
            InstituicaoRepositorio = new InstituicaoRepository();
        }

        [Authorize(Roles = "1, 2")]
        [HttpPost("cadastrar")]
        public IActionResult Cadastrar(Instituicoes instituicao)
        {
            try
            {
                InstituicaoRepositorio.Cadastrar(instituicao);
                return Ok("Instituição cadastrada com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro, não foi possível cadastrar instituição.");
            }
        }

        [Authorize(Roles = "1, 2")]
        [HttpPut("atualizar")]
        public IActionResult Atualizar(Instituicoes instituicao)
        {
            try
            {
                InstituicaoRepositorio.Atualizar(instituicao);
                return Ok("Informações atualizadas com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro, não foi possível atualizar informações.");
            }
        }

        [Authorize(Roles = "1, 2")]
        [HttpDelete("deletar/{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                InstituicaoRepositorio.Deletar(id);
                return Ok("Instituição removida do sistema.");
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro, não foi possível remover instituição do sistema.");
            }
        }

        [Authorize(Roles = "1, 2, 3")]
        [HttpGet("listar")]
        public IActionResult Listar()
        {
            try
            {
                return Ok(InstituicaoRepositorio.Listar());
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro, não foi possível listar instituições.");
            }
        }
    }
}