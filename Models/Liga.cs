using System;
using System.Collections.Generic;

namespace webapi.Models
{
    public partial class Liga
    {
        public Liga()
        {
            Usuarioligas = new HashSet<Usuarioliga>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public int CreatorUserid { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int IdTipoLiga { get; set; }

        public virtual CatTipoLiga IdTipoLigaNavigation { get; set; }
        public virtual ICollection<Usuarioliga> Usuarioligas { get; set; }
    }
}
