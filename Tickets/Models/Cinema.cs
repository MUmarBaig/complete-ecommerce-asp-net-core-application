using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Tickets.Data.Base;

namespace Tickets.Models
{
    public class Cinema:IEntityBase
    {
        [Key]
        public int Id { get; set; }


        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name required.")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 15.")]
        public string Name { get; set; }


        [Display(Name = "Description")]
        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }


        [Display(Name = "Logo Url")]
        [Required(ErrorMessage = "Logo is required.")]
        public string Logo { get; set; }

        //Relationships 
        public List<Movie> Movies { get; set; }
    }
}
