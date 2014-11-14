namespace TranslationSystem.Web.Controllers
{
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using TranslationSystem.Data.Common.Repository;
    using TranslationSystem.Data.Models;
    using TranslationSystem.Web.ViewModels.Home;

    public class HomeController : Controller
    {
        private readonly IDeletableEntityRepository<Record> records;

        public HomeController(IDeletableEntityRepository<Record> records)
        {
            this.records = records;
        }

        public ActionResult Index()
        {
            var model = this.records.All().Project().To<IndexBlogRecordViewModel>();

            return this.View(model);
        }
    }
}