using BackendApi_Vol.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi_Vol.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductPackagingController : ControllerBase
    {
        public OnlinestoreContext Context { get; }

        public ProductPackagingController(OnlinestoreContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GwtAll()
        {
            List<ProductPackaging> u = Context.ProductPackagings.ToList();
            return Ok(u);
        }

        [HttpGet("{id}")]

        public IActionResult GetById(string pack)
        {
            ProductPackaging? u = Context.ProductPackagings.Where(x => x.Packaging == pack).FirstOrDefault();
            if (u == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(u);
        }
        [HttpPost]
        public IActionResult Add(ProductPackaging u)
        {
            Context.ProductPackagings.Add(u);
            Context.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(ProductPackaging u)
        {
            Context.ProductPackagings.Update(u);
            Context.SaveChanges();
            return Ok(u);
        }
        [HttpDelete]
        public IActionResult Delete(string pack)
        {
            ProductPackaging? u = Context.ProductPackagings.Where(x => x.Packaging == pack).FirstOrDefault();
            if (u == null)
            {
                return BadRequest("Not Found");
            }
            Context.ProductPackagings.Remove(u);
            Context.SaveChanges();
            return Ok();

        }
    }
}
