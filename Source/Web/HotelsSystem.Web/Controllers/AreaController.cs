namespace HotelsSystem.Web.Controllers
{
    using System.Web.Mvc;

    using HotelsSystem.Data.Common.Repository;
    using HotelsSystem.Data.Models;
    using HotelsSystem.Web.InputModels.Area;


    public class AreaController : Controller
    {
        private readonly IDeletableEntityRepository<Area> areas;

        public AreaController(IDeletableEntityRepository<Area> areas)
        {
            this.areas = areas;
        }

        [Authorize]
        [HttpGet]
        public ActionResult Add()
        {
            var areaModel = new AddAreaInputModel();

            ViewBag.Areas = this.areas.All();

            return View(areaModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(AddAreaInputModel model)
        {
            if (ModelState.IsValid)
            {
                var area = new Area
                {
                    Name = model.Name
                };

                this.areas.Add(area);
                this.areas.SaveChanges();

                return this.RedirectToAction("Index", "Home");
            }

            ViewBag.Areas = this.areas.All();
            return this.View(model);
        }
    }
}