namespace Survivor.Entities
{
    public class BaseEntity// we created for the all property
    {

        public DateTime?  CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
