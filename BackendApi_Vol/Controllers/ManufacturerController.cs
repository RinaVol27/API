using BackendApi_Vol.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi_Vol.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturerController : ControllerBase
    {
        public OnlinestoreContext Context { get; }

        public ManufacturerController(OnlinestoreContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GwtAll()
        {
            List<Manufacturer> u = Context.Manufacturers.ToList();
            return Ok(u);
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            Manufacturer? u = Context.Manufacturers.Where(x => x.IdManufacturer == id).FirstOrDefault();
            if (u == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(u);
        }
        [HttpPost]
        public IActionResult Add(Manufacturer u)
        {
            Context.Manufacturers.Add(u);
            Context.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(Manufacturer u)
        {
            Context.Manufacturers.Update(u);
            Context.SaveChanges();
            return Ok(u);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Manufacturer? u = Context.Manufacturers.Where(x => x.IdManufacturer == id).FirstOrDefault();
            if (u == null)
            {
                return BadRequest("Not Found");
            }
            Context.Manufacturers.Remove(u);
            Context.SaveChanges();
            return Ok();

        }
    }
}
