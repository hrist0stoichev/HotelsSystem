namespace HotelsSystem.Web.Controllers
{
    using System.Web.Mvc;
    using System.Linq;

    using HotelsSystem.Data.Common.Repository;
    using HotelsSystem.Data.Models;
    using HotelsSystem.Web.ViewModels.HotelDetails;
    using AutoMapper.QueryableExtensions;

    public class HotelDetailsController : Controller
    {
        private readonly IDeletableEntityRepository<Place> places;
        private readonly IDeletableEntityRepository<Area> areas;

        public HotelDetailsController(IDeletableEntityRepository<Place> places, IDeletableEntityRepository<Area> areas)
        {
            this.places = places;
            this.areas = areas;
        }

        [HttpGet]
        public ActionResult GetDetails(string hotelName)
        {
            var hotel = this.places.All()
                .Where(h => h.Name == hotelName)
                .Project().To<PlaceDetailsViewModel>()
                .FirstOrDefault();

            if (hotel == null)
            {
                return HttpNotFound();
            }

            var actualHotel = this.places.All()
                .Where(h => h.Name == hotelName)
                .FirstOrDefault();

            actualHotel.TimesVisited++;

            places.SaveChanges();

            ViewBag.Areas = this.areas.All();
            return View(hotel);
        }
    }
}