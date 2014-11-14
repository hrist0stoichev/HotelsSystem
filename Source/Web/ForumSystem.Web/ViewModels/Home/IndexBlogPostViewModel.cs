namespace TranslationSystem.Web.ViewModels.Home
{
    using System.Collections.Generic;

    using TranslationSystem.Data.Models;
    using TranslationSystem.Web.Infrastructure.Mapping;

    public class IndexBlogRecordViewModel : IMapFrom<Record>
    {
        public string Word { get; set; }

        public ICollection<string> Definitions { get; set; }

        public int TimesTranslated { get; set; }
    }
}