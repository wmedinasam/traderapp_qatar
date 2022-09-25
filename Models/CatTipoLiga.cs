using System;
using System.Collections.Generic;

namespace webapi.Models
{
    public partial class CatTipoLiga
    {
        public CatTipoLiga()
        {
            Ligas = new HashSet<Liga>();
        }

        public int Id { get; set; }
        public EnumTipoLiga Descripcion { get; set; }

        public virtual ICollection<Liga> Ligas { get; set; }
    }

    public enum EnumTipoLiga{Apuesta,Diversion};
}
