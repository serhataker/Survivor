using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Survivor.Data;
using Survivor.Entities;

namespace Survivor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase, ICRUDController // Inherited ICRUD and controlbase
    {

        private readonly SurvivorContext _context;

        public CategoriesController(SurvivorContext survivorContext)// Dependicy Injection for the api controller

        {
            _context = survivorContext;
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var category = _context.Categories.Find(id);

            if (category == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(category);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var categories = _context.Categories.ToList(); 
            if (categories == null || !categories.Any())
            {
                return NoContent(); 
            }

            return Ok(categories); 
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null)
            {
                return NoContent(); 
            }

            return Ok(category); 
        }
        [HttpPost]
        public IActionResult Post([FromBody] CompetitorEntity competitor)
        {
            if (competitor == null)
            {
                return BadRequest("Competitor data is required."); 
            }

            // Check if the provided CategoryId is valid
            var categoryExists = _context.Categories.Any(c => c.Id == competitor.CategoryId);
            if (!categoryExists)
            {
                return BadRequest("Competitor must belong to a valid category."); 
            }

            // Add the competitor to the context
            _context.Competitors.Add(competitor);
            _context.SaveChanges(); 

            return CreatedAtAction(nameof(Get), new { id = competitor.Id }, competitor); 
        }


        [HttpPut]
        public IActionResult Put(int id, [FromBody] BaseEntity Category)
        {

            var category = _context.Categories.Find(id);

            if (category == null)
            {
                return NotFound(); 
            }
            category.IsDeleted = Category.IsDeleted;
           
            _context.SaveChanges(); 

            return NoContent(); 
        }

        
    }
}
