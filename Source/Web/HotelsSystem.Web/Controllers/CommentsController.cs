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
    using HotelsSystem.Web.InputModels.Comment;
    using Microsoft.AspNet.Identity;

    public class CommentsController : Controller
    {
        private readonly IDeletableEntityRepository<Comment> comments;
        private readonly IDeletableEntityRepository<Place> places;
        private readonly IDeletableEntityRepository<Area> areas;

        public CommentsController(IDeletableEntityRepository<Comment> comments, IDeletableEntityRepository<Place> places, IDeletableEntityRepository<Area> areas)
        {
            this.comments = comments;
            this.places = places;
            this.areas = areas;
        }

        [Authorize]
        [HttpGet]
        public ActionResult Add(string placeName)
        {
            if (placeName == null)
            {
                return HttpNotFound();
            }
            var commentModel = new AddCommentInputModel();


            ViewBag.Areas = this.areas.All();
            ViewBag.PlaceName = placeName;
            return View(commentModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(AddCommentInputModel model, string placeName)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.Identity.GetUserId();
                var place = this.places.All().Where(p => p.Name == placeName).FirstOrDefault();

                var comment = new Comment
                {
                    AuthorId = userId,
                    Content = model.Content,
                    PlaceId = place.Id
                };

                place.Comments.Add(comment);
                this.comments.Add(comment);
                

                this.comments.SaveChanges();
                this.places.SaveChanges();

                return this.RedirectToAction("GetDetails", "HotelDetails", new { hotelName = place.Name});
            }

            ViewBag.Areas = this.areas.All();
            return this.View(model);
        }
    }
}