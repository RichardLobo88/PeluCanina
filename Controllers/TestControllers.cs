using Microsoft.AspNetCore.Mvc;
using PeluqueriaCaninaApi.Data;
using PeluqueriaCaninaApi.Model;
using Dapper;
using System.Data.SqlClient;

using Microsoft.EntityFrameworkCore;


namespace PeluqueriaCaninaApi.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class TestControllers : ControllerBase
    {
        [HttpGet]

        public List<RegistroModel> GetRegistro() {


            var registroData = new RegistroData();

            return registroData.GetAllRegistro();


        }


        [HttpPost]
        public IActionResult Insert(RegistroModel registroModel)
        {

            int result = 0;
            using (var cnn = new SqlConnection("Server=DESKTOP-DKKNBKN;Database=PeluqueriaCanina; Integrated Security=true;Trusted_Connection=Yes"))
            {
                var sql = "insert into Usuarios(ID,Usuario,Contraseña)" +
                        " values(@Id,@Usuario,@Contraseña)";
                result = cnn.Execute(sql, registroModel);


            }

            return Ok(result);


        }



        



    }
}
