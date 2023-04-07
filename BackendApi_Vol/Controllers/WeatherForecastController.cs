using Microsoft.AspNetCore.Mvc;

namespace BackendApi_Vol.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static List<string> Summaries = new()
        {
            "Freezing",
            "Bracing",
            "Chilly",
            "Cool",
            "Mild",
            "Warm",
            "Balmy",
            "Hot",
            "Sweltering",
            "Scorching",
            "Hot",
            "Hot",
            "Mild"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]                   
        public List<string> Get()
        {
            return Summaries;
        }
        [HttpPost]
        public IActionResult Add(string name)
        {
            for (int i = 0; i < Summaries.Count; i++)
            {
                if (string.Equals(name, Summaries[i])) { return BadRequest("Duplicate value"); }
                else if (i + 1 == Summaries.Count && !string.Equals(name, Summaries[i]))
                {
                    Summaries.Add(name);
                }
            }
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(int index, string name)
        {
            if (index < 0 || index>= Summaries.Count)
            {
                return BadRequest("Invalid index");
            }
            else
            {
                for (int i = 0; i < Summaries.Count; i++)
                {
                    if (string.Equals(name, Summaries[i])) { return BadRequest("Duplicate value"); }
                    else if (i + 1 == Summaries.Count && !string.Equals(name, Summaries[i]))
                    {
                        Summaries[index] = name;
                    }
                }
                return Ok();
            }

        }
        [HttpDelete]
        public IActionResult Delete(int index)
        {
            if (index < 0 || index >= Summaries.Count)
            {
                return BadRequest("Invalid index");
            }
            else
            {
                Summaries.RemoveAt(index);
                return Ok();
            }
        }

        [HttpGet("{index}")]
        public IActionResult Output(int index)
        {
            if (index < 0 || index >= Summaries.Count)
            {
                return BadRequest("Invalid index");
            }
            else
            {
                string res = Summaries[index];
                return Ok(res);
            }
        }

        [HttpGet("find-by-name")]
        public IActionResult Counting(string name)
        {
            bool f = true;
            int count = 0;
            for(int i = 0; i < Summaries.Count; i++)
            {
                if (string.Equals(name, Summaries[i]))
                {
                    break;
                }
                else if (!string.Equals(name, Summaries[i]) && i+1==Summaries.Count)
                {
                    f = false;
                }
            }
            if (f)
            {
                foreach (string x in Summaries)
                {
                    if (x == name)
                        count++;
                }
                return Ok(count);
            }
            else
                return BadRequest("There is no such item in the list");
        }

        [HttpGet("All")]
        public IActionResult GetAll (int? sortStratery)
        {
            List <string> res = Summaries;
            if (sortStratery == null)
            {
                return Ok(Summaries);
            }
            else if (sortStratery == 1)
            {
                res.Sort();
                res.Reverse();
                return Ok(res);
            }
            else if (sortStratery == -1)
            {
                res.Sort();
                return Ok(res);
            }
            else
                return BadRequest("invalid parameter value");
        }


    }
}