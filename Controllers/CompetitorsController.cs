using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Survivor.Data;
using Survivor.Entities;
using System.Linq;

namespace Survivor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetitorsController : ControllerBase, ICRUDController// Inherited ICRUD and controlbase
    {
        private readonly SurvivorContext _context; // Dependicy Injection for the api controller

        public CompetitorsController(SurvivorContext survivorContext) // we process the for the constarintInjection
        {
            _context = survivorContext;
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var competitor = _context.Competitors.FirstOrDefault(c => c.Id == id);
            if (competitor == null)
                return NotFound(); // 404 Not Found

            _context.Competitors.Remove(competitor);
            _context.SaveChanges(); // Save changes to the database

            return NoContent(); // 204 No Content
        }

        [HttpGet]
        public IActionResult Get()
        {
            var competitors = _context.Competitors.ToList();
            if (competitors == null || !competitors.Any())
            {
                return NoContent(); // 204 No Content
            }

            return Ok(competitors); // 200 OK
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var competitor = _context.Competitors.Find(id);
            if (competitor == null)
            {
                return NotFound(); // 404 Not Found
            }

            return Ok(competitor); // 200 OK
        }

        [HttpGet("Categories/{categoryId}")]
        public IActionResult GetByCategoryId(int categoryId)
        {
            var competitors = _context.Competitors.Where(c => c.CategoryId == categoryId).ToList();
            if (competitors == null || !competitors.Any())
            {
                return NoContent(); // 204 No Content
            }

            return Ok(competitors); // 200 OK
        }

        [HttpPost]
        public IActionResult Post([FromBody] CompetitorEntity competitor)
        {
            if (competitor == null)
            {
                return BadRequest("Yarışmacı verisi gereklidir."); // 400 Bad Request
            }

            // Kategorinin mevcut olup olmadığını kontrol et
            var categoryExists = _context.Categories.Any(c => c.Id == competitor.CategoryId);
            if (!categoryExists)
            {
                return BadRequest("Yarışmacı, mevcut bir kategoriye ait olmalıdır."); // 400 Bad Request
            }

            // Yarışmacıyı ekle
            _context.Competitors.Add(competitor);
            _context.SaveChanges(); // Veritabanına kaydet

            return CreatedAtAction(nameof(Get), new { id = competitor.Id }, competitor); // 201 Created
        }




        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] BaseEntity competitor)
        {
            if (competitor == null)
            {
                return BadRequest(); // 400 Bad Request
            }

            var existingCompetitor = _context.Competitors.Find(id);
            if (existingCompetitor == null)
            {
                return NotFound(); // 404 Not Found
            }

            // Update properties
            existingCompetitor.ModifiedDate = competitor.ModifiedDate; // Example property
            // Add other fields as necessary

            _context.SaveChanges(); // Save changes to the database

            return NoContent(); // 204 No Content
        }
    }
}
