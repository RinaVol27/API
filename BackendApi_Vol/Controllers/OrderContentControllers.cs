using BackendApi_Vol.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi_Vol.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderContentControllers : ControllerBase
    {
        public OnlinestoreContext Context { get; }

        public OrderContentControllers(OnlinestoreContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GwtAll()
        {
            List<OrderContent> u = Context.OrderContents.ToList();
            return Ok(u);
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            OrderContent? u = Context.OrderContents.Where(x => x.IdOrder == id).FirstOrDefault();
            if (u == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(u);
        }
        [HttpPost]
        public IActionResult Add(OrderContent u)
        {
            Context.OrderContents.Add(u);
            Context.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(OrderContent u)
        {
            Context.OrderContents.Update(u);
            Context.SaveChanges();
            return Ok(u);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            OrderContent? u = Context.OrderContents.Where(x => x.IdOrder == id).FirstOrDefault();
            if (u == null)
            {
                return BadRequest("Not Found");
            }
            Context.OrderContents.Remove(u);
            Context.SaveChanges();
            return Ok();
        }
    }
}
