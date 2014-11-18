namespace HotelsSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;
    using HotelsSystem.Data.Common.Repository;
    using HotelsSystem.Data.Models;
    using HotelsSystem.Web.ViewModels.Home;
    using PagedList;
    using PagedList.Mvc;

    public class HomeController : Controller
    {
        private readonly IDeletableEntityRepository<Place> places;
        private readonly IDeletableEntityRepository<Area> areas;

        public HomeController(IDeletableEntityRepository<Place> places, IDeletableEntityRepository<Area> areas)
        {
            this.places = places;
            this.areas = areas;
        }

        [OutputCache(Duration = 60)]
        public ActionResult Index(int? page)
        {
            var hotels = this.places.All()
                .OrderBy(h => h.TimesVisited)
                .Project().To<IndexHotelViewModel>()
                .ToPagedList(page ?? 1, 20);

            ViewBag.Areas = this.areas.All();

            return this.View(hotels);
        }
    }
}