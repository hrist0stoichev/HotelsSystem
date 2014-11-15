namespace HotelsSystem.Web.ViewModels.Home
{
    using HotelsSystem.Data.Models;
    using HotelsSystem.Web.Infrastructure.Mapping;

    public class IndexHotelViewModel : IMapFrom<Hotel>
    {
        public string Name { get; set; }

        public int Stars { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        public string Area { get; set; }

        public string PhoneForReservation { get; set; }
    }
}