namespace HotelsSystem.Data.Models
{
    using HotelsSystem.Data.Common.Models;

    public class Comment : AuditInfo, IDeletableEntity
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public bool IsDeleted { get; set; }

        public System.DateTime? DeletedOn { get; set; }

        public int PlaceId { get; set; }

        public virtual Place Place { get; set; }
    }
}
