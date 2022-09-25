using System;
using System.Collections.Generic;

namespace webapi.Models
{
    public partial class Grupo
    {
        public Grupo()
        {
            Equipos = new HashSet<Equipo>();
            FasegruposResultados = new HashSet<FasegruposResultado>();
        }

        public int Id { get; set; }
        public string Grupo1 { get; set; }

        public virtual ICollection<Equipo> Equipos { get; set; }
        public virtual ICollection<FasegruposResultado> FasegruposResultados { get; set; }

    }
}
