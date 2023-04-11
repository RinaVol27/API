using BackendApi_Vol.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi_Vol.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOrderControllercs : ControllerBase
    {
        public OnlinestoreContext Context { get; }

        public UserOrderControllercs(OnlinestoreContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GwtAll()
        {
            List<UserOrder> u = Context.UserOrders.ToList();
            return Ok(u);
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            UserOrder? u = Context.UserOrders.Where(x => x.IdOrder == id).FirstOrDefault();
            if (u == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(u);
        }
        [HttpPost]
        public IActionResult Add(UserOrder u)
        {
            Context.UserOrders.Add(u);
            Context.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(UserOrder u)
        {
            Context.UserOrders.Update(u);
            Context.SaveChanges();
            return Ok(u);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            UserOrder? u = Context.UserOrders.Where(x => x.IdOrder == id).FirstOrDefault();
            if (u == null)
            {
                return BadRequest("Not Found");
            }
            Context.UserOrders.Remove(u);
            Context.SaveChanges();
            return Ok();

        }
    }
}
