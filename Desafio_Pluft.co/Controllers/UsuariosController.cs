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
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository UsuarioRepositorio { get; set; }

        public UsuariosController()
        {
            UsuarioRepositorio = new UsuarioRepository();
        }

        [Authorize(Roles = "1")]
        [HttpPost("cadastrar")]
        public IActionResult Cadastrar(Usuarios usuario)
        {
            try
            {
                UsuarioRepositorio.Cadastrar(usuario);
                return Ok("Cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro, não foi possível cadastrar usuario");
            }
        }

        [Authorize(Roles = "1, 2, 3")]
        [HttpPut("atualizar")]
        public IActionResult Atualizar(Usuarios usuario)
        {
            try
            {
                UsuarioRepositorio.Atualizar(usuario);
                return Ok("Atualizado com sucesso!");
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
                UsuarioRepositorio.Deletar(id);
                return Ok("Usuario removido do sistema.");
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro, não foi possível excluir usuario.");
            }
        }

        [Authorize(Roles = "1, 2")]
        [HttpGet("listar")]
        public IActionResult Listar()
        {
            try
            {
                return Ok(UsuarioRepositorio.Listar());
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro, não foi possível exibir lista de usuários.");
            }
        }
    }
}