﻿namespace HotelsSystem.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;
    using HotelsSystem.Data.Models;
    using HotelsSystem.Data.Common.Repository;
    using HotelsSystem.Web.InputModels.Hotel;

    public class HotelController : Controller
    {
        private readonly IDeletableEntityRepository<Place> places;
        private readonly IDeletableEntityRepository<Area> areas;

        public HotelController(IDeletableEntityRepository<Place> places, IDeletableEntityRepository<Area> areas)
        {
            this.places = places;
            this.areas = areas;
        }

        [HttpGet]
        [Authorize]
        public ActionResult Add()
        {
            var model = new AddInputModel();

            ViewBag.Stars = GenerateListItemsForStars();
            ViewBag.AreasList = GenerateListItemsForAreas();
            ViewBag.Areas = this.areas.All();

            return View(model);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Add(AddInputModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.Identity.GetUserId();

                var hotel = new Place
                {
                    Name = model.Name,
                    Description = model.Description,
                    HotelOwnerId = userId,
                    Price = model.Price,
                    Stars = model.Stars,
                    WebSite = model.WebSite,
                    PhoneForReservation = model.PhoneForReservation,
                    PhoneForReservation2 = model.PhoneForReservation2,
                    AvailablePlaces = model.AvailablePlaces,
                    Email = model.Email,
                    Adress = model.Adress,
                    AreaId = model.AreaId,
                    PlaceType = model.PlaceType
                };

                this.places.Add(hotel);
                this.places.SaveChanges();
                return this.RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Stars = GenerateListItemsForStars();
                ViewBag.AreasList = GenerateListItemsForAreas();
                ViewBag.Areas = this.areas.All();

                return this.View(model);
            }
        }

        private IEnumerable<SelectListItem> GenerateListItemsForAreas()
        {
            return this.areas.All().OrderBy(a => a.Name).Select(a => new SelectListItem()
            {
                Value = a.Id.ToString(),
                Text = a.Name
            });
        }

        private IEnumerable<SelectListItem> GenerateListItemsForStars()
        {
            var stars = new List<SelectListItem>();
            for (int i = 1; i < 8; i++)
            {
                stars.Add(new SelectListItem()
                {
                    Text = i.ToString(),
                    Value = i.ToString()
                });
            }

            return stars;
        }
    }
}