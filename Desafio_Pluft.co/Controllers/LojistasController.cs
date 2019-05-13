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
    public class LojistasController : ControllerBase
    {
        private ILojistaRepository LojistaRepositorio { get; set; }

        public LojistasController()
        {
            LojistaRepositorio = new LojistaRepository();
        }

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