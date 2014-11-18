namespace HotelsSystem.Web.ViewModels.HotelDetails
{
    using System.Collections.Generic;

    using HotelsSystem.Data.Models;
    using HotelsSystem.Web.Infrastructure.Mapping;

    public class PlaceDetailsViewModel : IMapFrom<Place>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string AreaName { get; set; }

        public string Adress { get; set; }

        public string PhoneForReservation { get; set; }

        public string PhoneForReservation2 { get; set; }

        public string Email { get; set; }

        public string WebSite { get; set; }

        public int Stars { get; set; }

        public int AvailablePlaces { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string HotelOwnerName { get; set; }

        public int TimesVisited { get; set; }

        public PlaceType PlaceType { get; set; }

        public virtual ICollection<Image> Images { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<Place, PlaceDetailsViewModel>()
                .ForMember(m => m.HotelOwnerName, opt => opt.MapFrom(f => f.HotelOwner.UserName))
                .ForMember(m => m.AreaName, opt => opt.MapFrom(f => f.Area.Name))
                .ReverseMap();
        }
    }
}