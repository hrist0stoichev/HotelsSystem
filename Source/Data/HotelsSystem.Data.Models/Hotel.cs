namespace HotelsSystem.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using HotelsSystem.Data.Common.Models;

    public class Hotel : AuditInfo, IDeletableEntity
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public int AreaId { get; set; }
        
        public virtual Area Area { get; set; }

        [MaxLength(50)]
        public string Adress { get; set; }

        [Required]
        [MaxLength(13)]
        public string PhoneForReservation { get; set; }

        [MaxLength(13)]
        [MinLength(9)]
        public string PhoneForReservation2 { get; set; }

        [MinLength(10)]
        [MaxLength(30)]
        public string Email { get; set; }

        [MinLength(5)]
        [MaxLength(50)]
        public string WebSite { get; set; }

        [Required]
        [Range(0, 7)]
        public int Stars { get; set; }

        [Range(0, 2000)]
        public int AvailablePlaces { get; set; }

        [Required]
        [MaxLength(2000)]
        public string Description { get; set; }

        [Required]
        [Range(0, 20000)]
        public decimal Price { get; set; }

        public string HotelOwnerId { get; set; }

        public virtual ApplicationUser HotelOwner { get; set; }

        public int TimesVisited { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
