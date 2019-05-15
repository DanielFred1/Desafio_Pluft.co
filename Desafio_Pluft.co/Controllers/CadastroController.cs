using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Desafio_Pluft.co.Domains;
using Desafio_Pluft.co.Interfaces;
using Desafio_Pluft.co.Repositories;
using Desafio_Pluft.co.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace Desafio_Pluft.co.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CadastroController : ControllerBase
    {
        private IUsuarioRepository UsuarioRepositorio { get; set; }

        public CadastroController()
        {
            UsuarioRepositorio = new UsuarioRepository();
        }

        [AllowAnonymous]
        [HttpPost("cadastre-se")]
        public IActionResult CadastroUsuario(Usuarios usuario)
        {
            try
            {
                Usuarios buscarUsuario = UsuarioRepositorio.BuscarPorEmailESenha(usuario.Email, usuario.Senha);
                if (buscarUsuario != null)
                {
                    return BadRequest("Email ou senha inválidos.");
                }
                UsuarioRepositorio.Cadastrar(usuario);
                return Ok("Cadastro efetuado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro, não foi possível concluir cadastro.");
            }
        }
    }
}