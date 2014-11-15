namespace HotelsSystem.Web.Controllers
{
    using System.Web.Mvc;
    using System.Linq;

    using AutoMapper.QueryableExtensions;

    using HotelsSystem.Data.Common.Repository;
    using HotelsSystem.Data.Models;
    using HotelsSystem.Web.ViewModels.Home;
    using PagedList;
    using System.Collections.Generic;

    public class HomeController : Controller
    {
        private readonly IDeletableEntityRepository<Hotel> hotels;

        public HomeController(IDeletableEntityRepository<Hotel> hotels)
        {
            this.hotels = hotels;
        }

        public ActionResult Index(int? page)
        {
            var hotels = this.hotels.All().OrderBy(h => h.Id).Project().To<IndexHotelViewModel>().ToPagedList(page ?? 1, 20);

            return this.View(hotels);
        }
    }
}