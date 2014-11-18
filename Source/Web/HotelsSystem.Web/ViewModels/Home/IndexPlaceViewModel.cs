namespace HotelsSystem.Web.ViewModels.Home
{
    using HotelsSystem.Data.Models;
    using HotelsSystem.Web.Infrastructure.Mapping;

    public class IndexHotelViewModel : IMapFrom<Place>
    {
        public string Name { get; set; }

        public int Stars { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public Area Area { get; set; }

        public string PhoneForReservation { get; set; }

        public PlaceType PlaceType { get; set; }
    }
}