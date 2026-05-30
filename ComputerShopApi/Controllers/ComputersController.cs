using ComputerShopApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComputerShopApi.Controllers
{
    [Route("computer")]
    [ApiController]
    public class ComputersController : ControllerBase
    {
        CmpShopDbContext context = new CmpShopDbContext();
        [HttpPost]
        public ActionResult AddNewComputer(AddComputerDto addComputerDto)
        {
            try
            {
                var computer = new Computers
                {
                    Brand = addComputerDto.Brand,
                    Type = addComputerDto.Type,
                    Display = addComputerDto.Display,
                    CreatedTime = DateTime.Now
                };

                context.computers.Add(computer);
                context.SaveChanges();
                return StatusCode(201, new { message = "Sikere felvétel", result = computer });
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { message = ex.Message });
            }
        }

        [HttpGet]
        public ActionResult GetAllComputer()
        {
            try
            {
                return StatusCode(200,
                    new { message = "Sikeres lekérdezés", result = context.computers.ToList() });
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { message = ex.Message });
            }
        }

        [HttpGet("id")]
        public ActionResult GetByIdComputer(int id)
        {
            try
            {
                var computer = context.computers.Find(id);
                return StatusCode(200,
                  new { message = "Sikeres lekérdezés", result = computer });
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { message = ex.Message });
            }
        }

        [HttpDelete]
        public ActionResult DeleteByIdComputer(int id) 
        {
            try
            {
                var computer = context.computers.FirstOrDefault(cmp => cmp.Id == id);

                if(computer != null)
                {
                    context.computers.Remove(computer);
                    context.SaveChanges();

                    return StatusCode(200,
                     new { message = "Sikeres törlés", result = computer });
                }

                return StatusCode(404,
                    new { message = "Nem létező Id!", result = computer });
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { message = ex.Message });
            }
        }

        [HttpPut]
        public ActionResult UpdateComputer(UpdateComputerDto updateComputerDto)
        {
            try
            {
                var existingComputer = context.computers.Find(updateComputerDto.Id);

                if (existingComputer != null)
                {
                    existingComputer.Brand = updateComputerDto.Brand;
                    existingComputer.Type = updateComputerDto.Type;
                    existingComputer.Display = updateComputerDto.Display;
                    existingComputer.UpdatedTime = DateTime.Now;

                    context.computers.Update(existingComputer);
                    context.SaveChanges();

                    return StatusCode(200,
                    new { message = "Sikeres frissítés", result = existingComputer });
                }

                return StatusCode(404,
                  new { message = "Nem létező Id!", result = existingComputer });
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { message = ex.Message });
            }
        }
    }
}
