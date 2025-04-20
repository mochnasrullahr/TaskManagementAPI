using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagementAPI.Data;
using TaskManagementAPI.Models;

namespace TaskManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TugasController(ApplicationDbContext context) : ControllerBase
    {
        private readonly ApplicationDbContext _context = context;

        // GET: api/Tugas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tugas>>> GetTugas()
        {
            return await _context.Tugas.ToListAsync();
        }

        // GET: api/Tugas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tugas>> GetTugas(int id)
        {
            var tugas = await _context.Tugas.FindAsync(id);

            if (tugas == null)
            {
                return NotFound();
            }

            return tugas;
        }

        // PUT: api/Tugas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTugas(int id, Tugas tugas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tugas.Id)
            {
                return BadRequest();
            }

            _context.Entry(tugas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TugasExists(id))
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

        // POST: api/Tugas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tugas>> PostTugas(Tugas tugas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Tugas.Add(tugas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTugas", new { id = tugas.Id }, tugas);
        }

        // DELETE: api/Tugas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTugas(int id)
        {
            var tugas = await _context.Tugas.FindAsync(id);
            if (tugas == null)
            {
                return NotFound();
            }

            _context.Tugas.Remove(tugas);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TugasExists(int id)
        {
            return _context.Tugas.Any(e => e.Id == id);
        }
    }
}
// > dotnet tool install --global dotnet-aspnet-codegenerator
// > dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
// > dotnet aspnet-codegenerator controller -name TugasController --model Tugas -dc ApplicationDbContext -api -outDir Controllers
