using System;
using System.Collections.Generic;

namespace Desafio_Pluft.co.Domains
{
    public partial class TipoUsuarios
    {
        public TipoUsuarios()
        {
            Lojistas = new HashSet<Lojistas>();
            Usuarios = new HashSet<Usuarios>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<Lojistas> Lojistas { get; set; }
        public ICollection<Usuarios> Usuarios { get; set; }
    }
}
