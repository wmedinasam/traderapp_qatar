using System;
using System.Collections.Generic;

namespace webapi.Models
{
    public partial class CatTipoUsuario
    {
        public CatTipoUsuario()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int Id { get; set; }
        public string Tipo { get; set; }
        public DateTime? FechaCreacion { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
