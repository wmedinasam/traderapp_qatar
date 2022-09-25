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

        public virtual Liga IdligaNavigation { get; set; }
        public virtual Usuario IdusuarioNavigation { get; set; }

    public Usuarioliga()
    {
        Id= 0;
        Idliga = 0;
        Idusuario = 0;
        MontoApuesta = 0;
    }

    public Usuarioliga(int id, int idliga, int idusuario)
    {
        this.Id = id;
        this.Idliga = idliga;
        this.Idusuario = idusuario;
        this.MontoApuesta = 0;
    }

    public Usuarioliga(int id, int idliga, int idusuario, decimal montoApuesta)
    {
        this.Id = id;
        this.Idliga = idliga;
        this.Idusuario = idusuario;
        this.MontoApuesta = montoApuesta;
    }


    }
}
