using System;
using System.Collections.Generic;

namespace webapi.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            FasegruposResultados = new HashSet<FasegruposResultado>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Pass { get; set; }
        public string Email { get; set; }
        public int Status { get; set; }
        public int Tipo { get; set; }
        public int Puntos { get; set; }

        public virtual CatTipoUsuario TipoNavigation { get; set; }
        public virtual ICollection<FasegruposResultado> FasegruposResultados { get; set; }
        //public virtual Fasegrupo FaseGrupoNavigation {get; set;}

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
