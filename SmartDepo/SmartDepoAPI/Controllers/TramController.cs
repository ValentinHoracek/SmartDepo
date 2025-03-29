using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartDepoAPI.Models;

namespace SmartDepoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TramController : ControllerBase
    {
        private readonly AppDbContext _context;

        public static readonly object Lock = new object();

        public TramController(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get all trams
        /// </summary>
        /// <returns>List of trams.</returns>
        // GET: api/<TramController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tram>>> Get()
        {
            return await _context.Depo.OrderBy(o => o.Order).ToListAsync();
        }

        /// <summary>
        /// Get next tram available tram.
        /// </summary>
        /// <returns>Tram that was scheduled.</returns>
        // GET: api/<TramController>/Next
        [HttpGet("Next")]
        public async Task<ActionResult<Tram>> GetNext()
        {
            lock (Lock)
            {
                var item = _context.Depo.OrderBy(o => o.Order).Where(w => !w.HasSchedule).FirstOrDefault();

                if (item is null)
                {
                    item = new Tram()
                    {
                        Order = _context.Depo.Max(m => m.Order) + 1,
                        HasSchedule = true
                    };
                    _context.Depo.Add(item);
                    _context.SaveChanges();

                    return CreatedAtAction("Get", new { id = item.Id }, item);
                }

                item.HasSchedule = true;

                _context.Entry(item).State = EntityState.Modified;

                try
                {
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TodoItemExists(item.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return item;
            }
        }

        /// <summary>
        /// Get tram by id.
        /// </summary>
        /// <param name="id">Id of tram</param>
        /// <returns>Selected tram.</returns>
        // GET api/<TramController>/{id}
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

        /// <summary>
        /// Update tram.
        /// </summary>
        /// <param name="id">Id of tram</param>
        /// <param name="item">Tram values to be updated</param>
        /// <returns></returns>
        // PUT api/<TramController>/{id}
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

        /// <summary>
        /// Add new tram.
        /// </summary>
        /// <param name="item">Tram object to be added</param>
        /// <returns>Tram that was created</returns>
        // POST api/<TramController>
        [HttpPost]
        public async Task<ActionResult<Tram>> Post([FromBody]Tram item)
        {
            _context.Depo.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = item.Id }, item);
        }

        /// <summary>
        /// Delete tram.
        /// </summary>
        /// <param name="id">Id of tram</param>
        /// <returns></returns>
        // DELETE api/<TramController>/{id}
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

        /// <summary>
        /// Check if tram exists.
        /// </summary>
        /// <param name="id">Id of tram</param>
        /// <returns>Returns true if tram exist in context.</returns>
        private bool TodoItemExists(long id)
        {
            return _context.Depo.Any(e => e.Id == id);
        }
    }
}
