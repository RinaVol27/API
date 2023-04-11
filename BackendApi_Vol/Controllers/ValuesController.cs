using BackendApi_Vol.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi_Vol.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public OnlinestoreContext Context { get; }

        public ValuesController(OnlinestoreContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GwtAll()
        {
            List<SiteUser> u = Context.SiteUsers.ToList();
            return Ok(u);
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            SiteUser? u = Context.SiteUsers.Where(x => x.IdUser == id).FirstOrDefault();
            if (u == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(u);
        }
        [HttpPost]
        public IActionResult Add(SiteUser u)
        {
            Context.SiteUsers.Add(u);
            Context.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(SiteUser u)
        {
            Context.SiteUsers.Update(u);
            Context.SaveChanges();
            return Ok(u);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            SiteUser? u = Context.SiteUsers.Where(x => x.IdUser == id).FirstOrDefault();
            if(u == null)
            {
                return BadRequest("Not Found");
            }
            Context.SiteUsers.Remove(u);
            Context.SaveChanges();
            return Ok();

        }
    }
}
