namespace HotelsSystem.Web.Controllers
{
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using HotelsSystem.Data.Common.Repository;
    using HotelsSystem.Data.Models;
    using HotelsSystem.Web.ViewModels.Home;

    public class HomeController : Controller
    {
        private readonly IDeletableEntityRepository<Hotel> hotels;

        public HomeController(IDeletableEntityRepository<Hotel> hotels)
        {
            this.hotels = hotels;
        }

        public ActionResult Index()
        {
            var model = this.hotels.All().Project().To<IndexHotelViewModel>();

            return this.View(model);
        }
    }
}