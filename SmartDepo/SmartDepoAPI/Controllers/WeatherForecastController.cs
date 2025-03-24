using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartDepoAPI.Models;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartDepoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherForecastController : ControllerBase
    {
        private readonly AppDbContext _context;

        public WeatherForecastController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/<WeatherForecastController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WeatherForecast>>> Get()
        {
            return await _context.WeatherForecasts.ToListAsync();
        }

        // GET api/<WeatherForecastController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WeatherForecast>> Get(int id)
        {
            var item = await _context.WeatherForecasts.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        // PUT api/<WeatherForecastController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody]WeatherForecast item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST api/<WeatherForecastController>
        [HttpPost]
        public async Task<ActionResult<WeatherForecast>> Post([FromBody]WeatherForecast item)
        {
            _context.WeatherForecasts.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = item.Id }, item);
        }

        // DELETE api/<WeatherForecastController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var item = await _context.WeatherForecasts.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            _context.WeatherForecasts.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TodoItemExists(long id)
        {
            return _context.WeatherForecasts.Any(e => e.Id == id);
        }
    }
}
