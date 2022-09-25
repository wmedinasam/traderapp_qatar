using System;
using System.Collections.Generic;

namespace webapi.Models
{
    public partial class CatStatusJuego
    {
        public CatStatusJuego()
        {
            Fasegrupos = new HashSet<Fasegrupo>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public DateTime? FechaCreacion { get; set; }

        public virtual ICollection<Fasegrupo> Fasegrupos { get; set; }
    }
}
