using ComputerWebAPI.Models;
using ComputerWebAPI.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComputerWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OsController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetAllOses()
        {
            try
            {
                using (var context = new ComputerDbContext())
                {
                    var oses = context.oses.ToList();
                    return Ok(new { message = "Sikeres lekérdezés", result = oses });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Hiba történt az adatok lekérésekor", error = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult AddNewOs(AddOsDto newos)
        {
            try
            {
                var os = new Os
                {
                    Name = newos.Name
                };
                using (var context = new ComputerDbContext())
                {
                    if (os != null)
                    {
                        context.oses.Add(os);
                        context.SaveChanges();
                        return StatusCode(201, new { message = "Sikeres hozzáadás", result = os });

                    }

                    return NotFound(new { message = "Hiba történt az adatok hozzáadásakor" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Hiba történt az adatok hozzáadásakor", error = ex.Message });
            }
        }



    }
}
