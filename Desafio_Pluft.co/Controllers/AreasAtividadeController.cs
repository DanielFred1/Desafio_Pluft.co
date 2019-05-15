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
    public class AreasAtividadeController : ControllerBase
    {
        private IAreasAtividadeRepository AreasAtividadeRepositorio { get; set; }

        public AreasAtividadeController()
        {
            AreasAtividadeRepositorio = new AreasAtividadeRepository();
        }

        [Authorize(Roles = "1, 2")]
        [HttpPost("cadastrar")]
        public IActionResult Cadastrar(AreasAtividade area)
        {
            try
            {
                AreasAtividadeRepositorio.Cadastrar(area);
                return Ok("Área cadastrada com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro, não foi possível cadastrar área de atuação.");
            }
        }

        [Authorize(Roles = "1, 2")]
        [HttpPut("atualizar")]
        public IActionResult Atualizar(AreasAtividade area)
        {
            try
            {
                AreasAtividadeRepositorio.Atualizar(area);
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
                AreasAtividadeRepositorio.Deletar(id);
                return Ok("Area removida do sistema.");
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro, não foi possível remover area do sistema.");
            }
        }

        [Authorize(Roles = "1, 2, 3")]
        [HttpGet("listar")]
        public IActionResult Listar()
        {
            try
            {
                return Ok(AreasAtividadeRepositorio.Listar());
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro, não foi possível listar áreas.");
            }
        }
    }
}