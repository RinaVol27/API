using BackendApi_Vol.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi_Vol.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DelieveryController : ControllerBase
    {
        public OnlinestoreContext Context { get; }

        public DelieveryController(OnlinestoreContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GwtAll()
        {
            List<Delivery> u = Context.Deliveries.ToList();
            return Ok(u);
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            Delivery? u = Context.Deliveries.Where(x => x.IdDelivery == id).FirstOrDefault();
            if (u == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(u);
        }
        [HttpPost]
        public IActionResult Add(Delivery u)
        {
            Context.Deliveries.Add(u);
            Context.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(Delivery u)
        {
            Context.Deliveries.Update(u);
            Context.SaveChanges();
            return Ok(u);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Delivery? u = Context.Deliveries.Where(x => x.IdDelivery == id).FirstOrDefault();
            if (u == null)
            {
                return BadRequest("Not Found");
            }
            Context.Deliveries.Remove(u);
            Context.SaveChanges();
            return Ok();

        }
    }
}
