using Microsoft.AspNetCore.Mvc;
using Survivor.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Filters;
using Survivor.Entities;
using System.Reflection.Emit;
namespace Survivor.Controllers
{

    public interface ICRUDController // defined for the all controller standart crud
    {


        [HttpGet]
        public IActionResult Get();

        [HttpGet("{id}")]
        public IActionResult Get(int id);

        [HttpPost]

        [HttpPut]

        public IActionResult Put(int id, [FromBody] BaseEntity bases);

        [HttpDelete]
        public IActionResult Delete(int id);


    

    }
}
