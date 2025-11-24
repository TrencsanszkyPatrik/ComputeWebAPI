using ComputerWebAPI.Models;
using ComputerWebAPI.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComputerWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComputerController : ControllerBase
    {
        [HttpPost]
        public ActionResult AddNewComputer(AddComputerDto comp)
        {
            try
            {
                var newComputer = new Computer
                {
                    Brand = comp.Brand,
                    Type = comp.Type,
                    Display = comp.Display,
                    Memory = comp.Memory,
                    CreatedTime = DateTime.Now,
                    OsId = comp.OsId
                };

                using (var context = new ComputerDbContext())
                {
                   if (newComputer != null)
                   {
                        context.computers.Add(newComputer);
                        context.SaveChanges();
                        return StatusCode(201, new {message = "Sikeres hozzáadás", result = newComputer});
                   
                   }
                   
                    return NotFound(new { message = "Hiba történt az adatok hozzáadásakor" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Hiba történt az adatok hozzáadásakor", error = ex.Message });
            }
        }

        [HttpGet]
        public ActionResult GetAllComputers()
        {
            try
            {
                using (var context = new ComputerDbContext())
                {
                    var computers = context.computers.ToList();
                    return Ok(new { message = "Sikeres lekérdezés", result = computers });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Hiba történt az adatok lekérésekor", error = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public ActionResult GetComputerById(int id)
        {
            try
            {
                using (var context = new ComputerDbContext())
                {
                    var computer = context.computers.Find(id);
                    if (computer != null)
                    {
                        return Ok(new { message = "Sikeres lekérdezés", result = computer });
                    }
                    return NotFound(new { message = "A megadott ID-vel nem található számítógép", result = "" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Hiba történt az adat lekérésekor", error = ex.Message });
            }
        }

    }
}
