using Microsoft.EntityFrameworkCore;
using PeluqueriaCaninaApi.Data;
using PeluqueriaCaninaApi.Model;
using System.Reflection.Metadata.Ecma335;

namespace PeluqueriaCaninaApi.Model
{
    /* public class PeluqueriasCaninaModel
     {
         public int ID { get; set; }
         public string Nombre { get; set; }
         public DateTime Horario { get; set; }


     }
    */

    public class Peluquero
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Horario_var { get; set; }
        public DateTime HoraFin { get; set; }
    }

    public class Turno
    {
        public int ID { get; set; }
        public int PeluqueroID { get; set; }
        public DateTime Fecha { get; set; }
        public int UsuarioId { get; set; }
    }

    public class PeluqueriaAPI
    {
        private List<Peluquero> peluqueros;
        private List<Turno> turnos;

        public PeluqueriaAPI()
        {
            peluqueros = new List<Peluquero>();
            turnos = new List<Turno>();
        }

        //obtener lista de peluqueros 
        public List<Peluquero> GetAllPeluqueros()
        {
            return peluqueros;
        }





        public List<Turno> CrearTurno()
        {
            //Necesito la info de la base de datos horario inicio del peluquero y Id del peluquero
            PeluqueroData data = new PeluqueroData();
            var peluqueros = data.ObtHorario();
            List<Turno> turnos = new List<Turno>();
            foreach (var peluquero in peluqueros)
            {
                //DateTime horaInicio = new DateTime(Fecha.Year, Fecha.Month, Fecha.Day, peluquero.HoraFin.Hour, peluquero.HoraFin.Minute, 0);
                //DateTime horaFin = new DateTime(Fecha.Year, Fecha.Month, Fecha.Day, peluquero.HoraFin.Hour, peluquero.HoraFin.Minute, 0);
               // var T = DateTime.Now;
                var T = DateTime.Parse(peluquero.Horario_var);

                
               // DateTime horario = new DateTime(T.Year, T.Month, T.Day, H.Hour, H.Minute, 0);


                for (int i = 0; i < 16; i++)
                {

                    Turno turno = new Turno();

                    turno.PeluqueroID = peluquero.ID;
                    turno.Fecha = T;
                    data.Insert_turno(turno.PeluqueroID,turno.Fecha);
                    T=T.AddMinutes(30);
                    turnos.Add(turno);
                }
            }
            return turnos;
        }

        public string SelTurno(int ID_Turno, int UsuarioId){
            string Salida;
            PeluqueroData data = new PeluqueroData();
            var turno = data.SelTurno(ID_Turno);
            if (turno.UsuarioId == 0)
            {
                turno.UsuarioId = UsuarioId;

                data.UpDateTurno(turno);
                return "Su turno es " + turno.Fecha;
            }
            else {
                return "El turno " + turno.Fecha + " No esta disponible";
            }
        }


        public void AddTurno(int peluquerioID, DateTime fecha, int usuarioId)
        {

            Turno nuevoTurno = new Turno
            {
                PeluqueroID = peluquerioID,
                Fecha = fecha,
                UsuarioId = usuarioId
            };

            turnos.Add(nuevoTurno);
        }
        public List<Turno> GetTurnosPorUsuario(int usuarioId)
        {
          
            PeluqueroData data = new PeluqueroData();
            return data.Turnos_Por_Usuario(usuarioId);
            
        }

        public List<Turno> GetTurnosPorPeluquero(int peluqueroId)
        {

            PeluqueroData data = new PeluqueroData();
            return data.Turnos_Por_Peluquero(peluqueroId);

        }








    }
}





