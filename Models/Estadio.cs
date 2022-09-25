using System;
using System.Collections.Generic;

namespace webapi.Models
{
    public partial class Estadio
    {
        public Estadio()
        {
            Fasegrupos = new HashSet<Fasegrupo>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime? FechaCreacion { get; set; }

        public virtual ICollection<Fasegrupo> Fasegrupos { get; set; }
    }
}
