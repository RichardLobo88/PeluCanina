using Dapper;
using Microsoft.AspNetCore;
using System.Data.SqlClient;
using PeluqueriaCaninaApi.Model;
using System.Linq;




namespace PeluqueriaCaninaApi.Data
    
{
    public class PeluqueroData
    {
        private readonly string conection_string = "Server=DESKTOP-DKKNBKN;Database=PeluqueriaCanina; Integrated Security = true; Trusted_Connection=Yes;";
        public List<Peluquero> GetAllPeluqueros()
        {
            List<Peluquero> list = new List<Peluquero>();
            try
            {



                using (SqlConnection cnn = new SqlConnection(conection_string))
                {

                    string query = "SELECT ID, Nombre FROM Peluqueros";
                    list = cnn.Query<Peluquero>(query).ToList();
                }
            }
            catch (Exception X) { }

            return list;

        }
              

        public List<Turno> GetTurnosPorUsuario()
        {
            List<Turno> list = new List<Turno>();
            try
            {



                using (SqlConnection cnn = new SqlConnection(conection_string))
                {

                    string query = "SELECT ID, Horario FROM Peluqueros";
                    list = cnn.Query<Turno>(query).ToList();
                }
            }
            catch (Exception X) { }

            return list;




        }

        public List<Peluquero> ObtHorario()
        {
            List<Peluquero> list = new List<Peluquero>();
            try
            {



                using (SqlConnection cnn = new SqlConnection(conection_string))
                {

                    string query = "SELECT * FROM Peluqueros";
                    list = cnn.Query<Peluquero>(query).ToList();
                }
            }
            catch (Exception X) { }

            return list;




        }


        public void Insert_turno( int PeluqueroID, DateTime Fecha) {

            try
            {

                

                using (SqlConnection cnn = new SqlConnection(conection_string))
                {
                    string format = "yyyy-MM-dd HH:mm:ss";
                    string query = "Insert into Turnos (PeluqueroID,Fecha,UsuarioId) Values ("+PeluqueroID +",'"+Fecha.ToString(format)+"',0)";
                    cnn.Query(query);
                }
            }
            catch (Exception X) { }
                  

        }


        public Turno SelTurno(int ID_turno)
        {

            Turno turno = new Turno();

            try
            {
                using (SqlConnection cnn = new SqlConnection(conection_string))
                {
                   
                    string query = "SELECT * FROM Turnos WHERE ID ="+ ID_turno;
                    turno = cnn.Query<Turno>(query).FirstOrDefault();
                    
                }
            }
            catch (Exception X) { }

            return turno;
        }

        public Turno UpDateTurno(Turno turno)
        {

           
            try
            {
                using (SqlConnection cnn = new SqlConnection(conection_string))
                {

                    string query = "UPDATE Turnos SET UsuarioId = " + turno.UsuarioId +"WHERE Id = " + turno.ID;
                    cnn.Query(query);

                }
            }
            catch (Exception X) { }

            return turno;
        }


        public List<Turno> Turnos_Por_Usuario(int usuarioId)
        {
            List<Turno> list = new List<Turno>();
            try
            {
                using (SqlConnection cnn = new SqlConnection(conection_string))
                {
                    string query = "SELECT * FROM Turnos WHERE usuarioID=" + usuarioId;
                    list = cnn.Query<Turno>(query).ToList();
                }
            }
            catch (Exception X) { }
            return list;

        }

        public List<Turno> Turnos_Por_Peluquero(int peluqueroId)
        {   //Peluqueros disponibles
            List<Turno> list = new List<Turno>();
            try
            {
                using (SqlConnection cnn = new SqlConnection(conection_string))
                {
                    string query = "SELECT * FROM Turnos WHERE UsuarioId=0 AND peluqueroID=" + peluqueroId;
                    list = cnn.Query<Turno>(query).ToList();
                }
            }
            catch (Exception X) { }
            return list;

        }



    }

    /*
    public List<DateTime> GetAllHoursPeluqueros(int Peluquero, DateTime Fecha)
    {


        List<DateTime> turnosDisponibles = new List<DateTime>();

        
        try
        {

            using (SqlConnection cnn = new SqlConnection(conection_string))
            {

                string query = "SELECT Horario FROM Peluqueros";
               turnosDisponibles = cnn.Query<PeluqueriasCaninaModel>(query).ToList();
            }

        }
        catch (Exception X) { }

        return turnosDisponibles;
    }
    */
}
