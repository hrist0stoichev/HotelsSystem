namespace HotelsSystem.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using HotelsSystem.Data.Common.Repository;
    using HotelsSystem.Data.Models;
    using AutoMapper.QueryableExtensions;
    using HotelsSystem.Web.ViewModels.Home;

    using PagedList;
    using PagedList.Mvc;

    public class SearchPlaceController : Controller
    {
        private readonly IDeletableEntityRepository<Place> places;
        private readonly IDeletableEntityRepository<Area> areas;

        public SearchPlaceController(IDeletableEntityRepository<Place> places, IDeletableEntityRepository<Area> areas)
        {
            this.places = places;
            this.areas = areas;
        }

        public ActionResult Index(int? page, string areaName, string placeType)
        {
            IPagedList hotels;
            hotels = this.places.All()
                .Where(h => h.Area.Name == areaName)
                .OrderBy(h => h.TimesVisited)
                .Project().To<IndexHotelViewModel>()
                .ToPagedList(page ?? 1, 20);
            if (!string.IsNullOrEmpty(placeType))
            {
                hotels = this.places.All()
                .Where(h => h.Area.Name == areaName)
                .Where(h => h.PlaceType.ToString() == placeType)
                .OrderBy(h => h.TimesVisited)
                .Project().To<IndexHotelViewModel>()
                .ToPagedList(page ?? 1, 20);
            }



            ViewBag.Areas = this.areas.All();
            ViewBag.PlaceType = placeType;
            ViewBag.AreaName = areaName;
            return this.View(hotels);
        }
    }
}