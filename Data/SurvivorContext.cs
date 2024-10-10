using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

using Survivor.Entities;

namespace Survivor.Data
{
    public class SurvivorContext:DbContext
    {
        public SurvivorContext(DbContextOptions<SurvivorContext> options) : base(options) { }

      

       public  DbSet<CategoryEntity> Categories { get; set; }
       public  DbSet<CompetitorEntity>Competitors { get; set; }
    }
}
