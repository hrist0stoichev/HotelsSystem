namespace TranslationSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Record
    {
        public int Id { get; set; }

        [Index]
        public string Word { get; set; }

        public ICollection<string> Definitions { get; set; }

        public virtual RecordStatus RecordStatus { get; set; }

        public int TimesTranslated { get; set; }
    }
}
