using BackendApi_Vol.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi_Vol.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        public OnlinestoreContext Context { get; }

        public ProductCategoryController(OnlinestoreContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GwtAll()
        {
            List<ProductCategory> u = Context.ProductCategories.ToList();
            return Ok(u);
        }

        [HttpGet("{id}")]

        public IActionResult GetById(string cat)
        {
            ProductCategory? u = Context.ProductCategories.Where(x => x.Category == cat).FirstOrDefault();
            if (u == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(u);
        }
        [HttpPost]
        public IActionResult Add(ProductCategory u)
        {
            Context.ProductCategories.Add(u);
            Context.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(ProductCategory u)
        {
            Context.ProductCategories.Update(u);
            Context.SaveChanges();
            return Ok(u);
        }
        [HttpDelete]
        public IActionResult Delete(string category)
        {
            ProductCategory? u = Context.ProductCategories.Where(x => x.Category == category).FirstOrDefault();
            if (u == null)
            {
                return BadRequest("Not Found");
            }
            Context.ProductCategories.Remove(u);
            Context.SaveChanges();
            return Ok();

        }
    }
}
