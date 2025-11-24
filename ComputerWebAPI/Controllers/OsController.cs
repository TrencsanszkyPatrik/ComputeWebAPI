using ComputerWebAPI.Models;
using ComputerWebAPI.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet("{id}")]
        public ActionResult GetOsById(int id)
        {
            try
            {
                using (var context = new ComputerDbContext())
                {
                    var os = context.oses.Find(id);
                    if (os != null)
                    {
                        return Ok(new { message = "Sikeres lekérdezés", result = os });
                    }
                    return NotFound(new { message = "Nem található os", result = "" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Hiba", error = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                using (var context = new ComputerDbContext())
                {
                    var os =  context.oses.Find(id);
                    if (os != null)
                    {
                        context.oses.Remove(os);
                        context.SaveChanges();
                        return Ok(new { message = "Sikeres törlés", result = os });
                    }
                    return NotFound(new { message = "Nincs ilyen számítógép", result = "" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Hiba", error = ex.Message });
            }
        }

        [HttpPut]
        public ActionResult UpdateOs(int id, AddOsDto updateos)
        {

            try
            {
                using (var context = new ComputerDbContext())
                {
                    var os = context.oses.Find(id);
                    if (os != null)
                    {
                        os.Name = updateos.Name;
                        context.SaveChanges();
                        return Ok(new { message = "Sikeres frissítés", result = os });
                    }
                    return NotFound(new { message = "Nincs ilyen számítógép", result = "" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Hiba történt az adatok frissítésekor", error = ex.Message });
            }
        }

        [HttpGet("with-computers")]
        public ActionResult GettAllOsWithComputer()
        {
            try
            {
                using (var context = new ComputerDbContext())
                {
                    var oses = context.oses
                        .Include(o => o.Computers)
                        .ToList();

                    return Ok(new { message = "Sikeres lekérdezés", result = oses });
                }
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Hiba" });
            }
        }

    }
}
