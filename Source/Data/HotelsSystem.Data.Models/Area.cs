namespace HotelsSystem.Data.Models
{
    using HotelsSystem.Data.Common.Models;

    public class Area : AuditInfo, IDeletableEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsDeleted { get; set; }

        public System.DateTime? DeletedOn { get; set; }
    }
}
