using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Survivor.Entities
{
    public class CompetitorEntity:BaseEntity // we defined for the one to many and  properties
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CategoryId {  get; set; }

        [ForeignKey(nameof(CategoryId))]
        public CategoryEntity Category { get; set; }
    }
}
