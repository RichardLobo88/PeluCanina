using PeluqueriaCaninaApi.Model;
using Dapper;
using System.Data.SqlClient;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection.PortableExecutable;
using System.Transactions;
using Microsoft.Win32;
using PeluqueriaCaninaApi.Data;
using Microsoft.AspNetCore.Mvc;


public class RegistroData
{

    public List<RegistroModel> GetAllRegistro()
    {
        List<RegistroModel> list = new List<RegistroModel>();
        try
        {
            using (var cnn = new SqlConnection("Server=DESKTOP-DKKNBKN;Database=PeluqueriaCanina; Integrated Security=true;Trusted_Connection=Yes"))
            {
                var query = "SELECT *FROM Usuarios";
                list = cnn.Query<RegistroModel>(query).ToList();
            }
        }
        catch (Exception X) { }

        return list;

    }

       
}
