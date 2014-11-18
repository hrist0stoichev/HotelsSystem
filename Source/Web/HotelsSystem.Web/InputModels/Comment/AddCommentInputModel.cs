namespace HotelsSystem.Web.InputModels.Comment
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    public class AddCommentInputModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(2000)]
        [Display(Name = "Съдържание")]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
    }
}