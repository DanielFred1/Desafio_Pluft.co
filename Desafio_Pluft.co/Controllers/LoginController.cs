﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Desafio_Pluft.co.Domains;
using Desafio_Pluft.co.Interfaces;
using Desafio_Pluft.co.Repositories;
using Desafio_Pluft.co.ViewModels;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace Desafio_Pluft.co.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository UsuarioRepositorio { get; set; }

        public LoginController()
        {
            UsuarioRepositorio = new UsuarioRepository();
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login(LoginViewModel login)
        {
            try
            {
                Usuarios buscaUsuario = UsuarioRepositorio.BuscarPorEmailESenha(login.Email, login.Senha);

                if (buscaUsuario == null)
                {
                    return NotFound("Não foi possível efetuar login, email ou senha inválidos.");
                }

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, buscaUsuario.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, buscaUsuario.Id.ToString()),
                    new Claim(ClaimTypes.Role, buscaUsuario.IdTipoUsuarioNavigation.Id.ToString()),
                    new Claim("Role", buscaUsuario.IdTipoUsuarioNavigation.Id.ToString())
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("pluft-chave-autenticacao"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "Pluft.WebApi",
                    audience: "Pluft.WebApi",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds
                    );

                return Ok(
                        new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(token)
                        }
                    );
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro, não foi possível efetuar login.");
            }
        }
    }
}