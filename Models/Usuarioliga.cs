using System;
using System.Collections.Generic;

namespace webapi.Models
{
    public partial class Usuarioliga
    {
        public int Id { get; set; }
        public int Idliga { get; set; }
        public int Idusuario { get; set; }
        public decimal MontoApuesta { get; set; }
        public int? Punteo { get; set; }

        public virtual Liga IdligaNavigation { get; set; }
        public virtual Usuario IdusuarioNavigation { get; set; }
    }
}
