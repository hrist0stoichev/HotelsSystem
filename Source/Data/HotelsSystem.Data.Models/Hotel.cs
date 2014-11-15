namespace HotelsSystem.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using HotelsSystem.Data.Common.Models;

    public class Hotel : AuditInfo, IDeletableEntity
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        //// TODO: Author, 

        public int Stars { get; set; }

        public string Description { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public string Price { get; set; }

        public string Area { get; set; }

        public string PhoneForReservation { get; set; }
    }
}
