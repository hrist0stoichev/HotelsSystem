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

        public HomeController(IDeletableEntityRepository<Place> places)
        {
            this.places = places;
        }

        public ActionResult Index(int? page)
        {
            var hotels = this.places.All()
                .OrderBy(h => h.TimesVisited)
                .Project().To<IndexHotelViewModel>()
                .ToPagedList(page ?? 1, 20);

            return this.View(hotels);
        }
    }
}