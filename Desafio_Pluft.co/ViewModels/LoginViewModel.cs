using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Desafio_Pluft.co.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Insira um email para continuar.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Insira uma senha para continuar.")]
        public string Senha { get; set; }
    }
}
