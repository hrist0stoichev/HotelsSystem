namespace HotelsSystem.Data.Models
{
    using System;

    using HotelsSystem.Data.Common.Models;

    public class Area : AuditInfo, IDeletableEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
