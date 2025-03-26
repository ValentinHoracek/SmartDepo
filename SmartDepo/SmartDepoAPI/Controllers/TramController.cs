using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartDepoAPI.Models;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartDepoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TramController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TramController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/<TramController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tram>>> Get()
        {
            return await _context.Depo.ToListAsync();
        }

        // GET api/<TramController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tram>> Get(int id)
        {
            var item = await _context.Depo.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        // PUT api/<TramController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody]Tram item)
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

        // POST api/<TramController>
        [HttpPost]
        public async Task<ActionResult<Tram>> Post([FromBody]Tram item)
        {
            _context.Depo.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = item.Id }, item);
        }

        // DELETE api/<TramController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var item = await _context.Depo.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            _context.Depo.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TodoItemExists(long id)
        {
            return _context.Depo.Any(e => e.Id == id);
        }
    }
}
