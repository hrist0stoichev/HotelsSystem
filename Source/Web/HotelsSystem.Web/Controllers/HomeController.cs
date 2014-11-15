namespace HotelsSystem.Web.Controllers
{
    using System.Web.Mvc;
    using System.Linq;

    using AutoMapper.QueryableExtensions;

    using HotelsSystem.Data.Common.Repository;
    using HotelsSystem.Data.Models;
    using HotelsSystem.Web.ViewModels.Home;
    using PagedList;

    public class HomeController : Controller
    {
        private readonly IDeletableEntityRepository<Hotel> hotels;
        private readonly IDeletableEntityRepository<Area> areas;

        public HomeController(IDeletableEntityRepository<Hotel> hotels, IDeletableEntityRepository<Hotel> areas)
        {
            this.hotels = hotels;
            this.areas = areas;
        }

        public ActionResult Index(int? page)
        {
            var hotels = this.hotels.All().OrderBy(h => h.Id).Project().To<IndexHotelViewModel>().ToPagedList(page ?? 1, 20);
            var areas = this.areas.All().OrderBy(a => a.Name);
            ViewBag.Areas = areas;

            return this.View(hotels);
        }
    }
}