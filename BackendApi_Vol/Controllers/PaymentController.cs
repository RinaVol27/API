using BackendApi_Vol.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi_Vol.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        public OnlinestoreContext Context { get; }

        public PaymentController(OnlinestoreContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GwtAll()
        {
            List<Payment> u = Context.Payments.ToList();
            return Ok(u);
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            Payment? u = Context.Payments.Where(x => x.IdPayment == id).FirstOrDefault();
            if (u == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(u);
        }
        [HttpPost]
        public IActionResult Add(Payment u)
        {
            Context.Payments.Add(u);
            Context.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(Payment u)
        {
            Context.Payments.Update(u);
            Context.SaveChanges();
            return Ok(u);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Payment? u = Context.Payments.Where(x => x.IdPayment == id).FirstOrDefault();
            if (u == null)
            {
                return BadRequest("Not Found");
            }
            Context.Payments.Remove(u);
            Context.SaveChanges();
            return Ok();
        }
    }
}
