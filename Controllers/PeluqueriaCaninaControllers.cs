using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeluqueriaCaninaApi.Data;
using PeluqueriaCaninaApi.Model;
using System.Diagnostics.CodeAnalysis;

namespace PeluqueriaCaninaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PeluqueriaCaninaControllers : ControllerBase
    {



        [HttpGet("AllPeluquería")]
        public ActionResult GetTodoItem()
        {

            var peluqueroData = new PeluqueroData();

            var todoItem = peluqueroData.GetAllPeluqueros();

            if (todoItem == null)
            {
                return NotFound();
            }

            return Ok(todoItem);
        }



                    


    } 
}
