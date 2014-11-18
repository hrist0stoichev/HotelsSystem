using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelsSystem.Web.InputModels.Area
{
    public class AddAreaInputModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(5)]
        [Display(Name = "Град/Село")]
        [DataType(DataType.Text)]
        public string Name { get; set; }
    }
}