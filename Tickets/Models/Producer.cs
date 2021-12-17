using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Tickets.Data.Base;

namespace Tickets.Models
{
    public class Producer:IEntityBase
    {
        [Key]
        public int Id { get; set; }


        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full Name required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "FullName must be between 3 and 50.")]
        public string FullName { get; set; }


        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Biography required.")]
        public string Bio { get; set; }


        [Display(Name = "Profile Picture Url")]
        [Required(ErrorMessage = "Profile Picture required.")]
        public string ProfilePictureURL { get; set; }

        //Relationships

        public List<Movie> Movies { get; set; }
    }
}
