using BackendApi_Vol.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi_Vol.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public OnlinestoreContext Context { get; }

        public ProductController(OnlinestoreContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GwtAll()
        {
            List<Product> u = Context.Products.ToList();
            return Ok(u);
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            Product? u = Context.Products.Where(x => x.IdProduct == id).FirstOrDefault();
            if (u == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(u);
        }
        [HttpGet("{category}")]

        public IActionResult GetByCategory(string category)
        {
            var u = Context.Products.Where(x => x.Category == category);
            if (u == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(u);
        }
        [HttpGet]

        public IActionResult GetAllSorted()
        {
            var u = Context.Products.OrderBy(x => x.Price);
            if (u == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(u);
        }

        [HttpGet]

        public IActionResult GetAllSortedDesc()
        {
            var u = Context.Products.OrderByDescending(x => x.Price);
            if (u == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(u);
        }
        [HttpPost]
        public IActionResult Add(Product u)
        {
            Context.Products.Add(u);
            Context.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(Product u)
        {
            Context.Products.Update(u);
            Context.SaveChanges();
            return Ok(u);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Product? u = Context.Products.Where(x => x.IdProduct == id).FirstOrDefault();
            if (u == null)
            {
                return BadRequest("Not Found");
            }
            Context.Products.Remove(u);
            Context.SaveChanges();
            return Ok();

        }
    }
}
