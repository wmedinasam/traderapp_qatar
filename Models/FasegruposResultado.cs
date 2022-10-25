using System;
using System.Collections.Generic;

namespace webapi.Models
{
    public partial class FasegruposResultado
    {
        public int Id { get; set; }
        public int Userid { get; set; }
        public int Grupo { get; set; }
        public int Idjuego { get; set; }
        public int IdEquipoa { get; set; }
        public int EquipoaGol { get; set; }
        public int IdEquipob { get; set; }
        public int EquipobGol { get; set; }

        public virtual Grupo GrupoNavigation { get; set; }
        public virtual Fasegrupo IdjuegoNavigation { get; set; }
        public virtual Usuario User { get; set; }
    }
}
