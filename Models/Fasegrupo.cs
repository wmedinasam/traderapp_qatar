using System;
using System.Collections.Generic;

namespace webapi.Models
{
    public partial class Fasegrupo
    {
        public int Id { get; set; }
        public int Equipoa { get; set; }
        public int Equipob { get; set; }
        public int Grupo { get; set; }
        public DateTime? Fechayhora { get; set; }
        public int Estadio { get; set; }
        public int EstadoJuego { get; set; }

        public virtual Equipo EquipoaNavigation { get; set; }
        public virtual Equipo EquipobNavigation { get; set; }
        public virtual Estadio EstadioNavigation { get; set; }
        public virtual CatStatusJuego EstadoJuegoNavigation { get; set; }
    }
}
