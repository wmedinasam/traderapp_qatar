using System;
using System.Collections.Generic;

namespace webapi.Models
{
    public partial class Equipo
    {
        public Equipo()
        {
            FasegrupoEquipoaNavigations = new HashSet<Fasegrupo>();
            FasegrupoEquipobNavigations = new HashSet<Fasegrupo>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Grupo { get; set; }
        public int Pj { get; set; }
        public int Pg { get; set; }
        public int Pe { get; set; }
        public int Pp { get; set; }
        public int Puntos { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }

        public virtual Grupo GrupoNavigation { get; set; }
        public virtual ICollection<Fasegrupo> FasegrupoEquipoaNavigations { get; set; }
        public virtual ICollection<Fasegrupo> FasegrupoEquipobNavigations { get; set; }
    }
}
