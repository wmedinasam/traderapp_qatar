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
         public int Punteo { get; set; }


        public virtual Liga IdligaNavigation { get; set; }
        public virtual Usuario IdusuarioNavigation { get; set; }

    public Usuarioliga()
    {
        Id= 0;
        Idliga = 0;
        Idusuario = 0;
        MontoApuesta = 0;
        Punteo = 0;
    }

    public Usuarioliga(int id, int idliga, int idusuario)
    {
        this.Id = id;
        this.Idliga = idliga;
        this.Idusuario = idusuario;
        this.MontoApuesta = 0;
    }

    public Usuarioliga(int id, int idliga, int idusuario, decimal montoApuesta, int punteo)
    {
        this.Id = id;
        this.Idliga = idliga;
        this.Idusuario = idusuario;
        this.MontoApuesta = montoApuesta;
        this.Punteo = punteo;
    }

    // Devolverá el equipo ganador del partido según el resultado real ingresado, en caso de empate devuelve 0
        private int devuelveEquipoGanador(Fasegrupo partido)
        {
            int equipoGanador = 0;
            if(partido.EquipoaGol>partido.EquipobGol)
            {
                equipoGanador = partido.Equipoa;
            }
            else if(partido.EquipoaGol<partido.EquipobGol)
            {
                equipoGanador = partido.Equipob;
            }
            else if(partido.EquipoaGol==partido.EquipobGol)
            {
                equipoGanador = 0;
            }// En caso de empate
            return equipoGanador;
        }
        // Devolverá el equipo ganador de la quiniela ingresada por el usuario, en caso de empate devuelve 0
        private int devuelveEquipoGanadorQuiniela(FasegruposResultado partido)
        {
            int equipoGanador = 0;
            if(partido.EquipoaGol>partido.EquipobGol)
            {
                equipoGanador = partido.IdEquipoa;
            }
            else if(partido.EquipoaGol<partido.EquipobGol)
            {
                equipoGanador = partido.IdEquipob;
            }
            else if(partido.EquipoaGol==partido.EquipobGol)
            {
                equipoGanador = 0;
            }// En caso de empate
            return equipoGanador;
        }

        // Retorna el punteo del partido para el usuario según su vaticinio
        public int obtenerPunteo(Fasegrupo resultado, FasegruposResultado vaticinio)
        {
            int punteo = 0;
            // si acierta
            if(devuelveEquipoGanador(resultado)==devuelveEquipoGanadorQuiniela(vaticinio))
            {
                // si es empate
                if(devuelveEquipoGanador(resultado)==0)
                {
                    punteo = 1;
                }
                // verifica resultados
                else if((resultado.EquipoaGol==vaticinio.EquipoaGol) && (resultado.EquipobGol==vaticinio.EquipobGol))
                {
                    punteo = 3;
                }
                else
                {
                    punteo = 1;
                }
            }
            // si no acierta siempre devuelve 0
            return punteo;
        }


    }
}
