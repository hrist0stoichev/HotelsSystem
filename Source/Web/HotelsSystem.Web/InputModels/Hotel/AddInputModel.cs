namespace HotelsSystem.Web.InputModels.Hotel
{
    using HotelsSystem.Data.Models;
    using HotelsSystem.Web.Infrastructure.Mapping;
    using System.ComponentModel.DataAnnotations;

    public class AddInputModel : IMapFrom<Place>
    {
        [Required]
        [MaxLength(100)]
        [Display(Name = "Име")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Област")]
        public int AreaId { get; set; }

        [MaxLength(50)]
        [Display(Name = "Адрес")]
        [DataType(DataType.MultilineText)]
        public string Adress { get; set; }

        [Required]
        [MaxLength(13)]
        [Display(Name = "Телефон за резервации")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneForReservation { get; set; }

        [MaxLength(13)]
        [MinLength(9)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Допълнителен телефон за резервации")]
        public string PhoneForReservation2 { get; set; }

        [MinLength(10)]
        [MaxLength(30)]
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [MinLength(5)]
        [MaxLength(50)]
        [Display(Name = "Website")]
        [DataType(DataType.Url)]
        public string WebSite { get; set; }

        [Required]
        [Range(1, 7)]
        [Display(Name = "Звезди")]
        public int Stars { get; set; }

        [Range(1, 2000)]
        [Display(Name = "Свободни места")]
        public int AvailablePlaces { get; set; }

        [Required]
        [MaxLength(2000)]
        [Display(Name = "Описание")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        [Range(1, 20000)]
        [Display(Name = "Цена за нощувка")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Display(Name = "Тип")]
        public PlaceType PlaceType { get; set; }
    }
}