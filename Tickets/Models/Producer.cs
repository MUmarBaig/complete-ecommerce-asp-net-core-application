using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Tickets.Data.Base;

namespace Tickets.Models
{
    public class Producer:IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Full Name")]
        public string FullName { get; set; }
        [Display(Name = "Biography")]
        public string Bio { get; set; }
        [Display(Name = "Profile Picture Url")]
        public string ProfilePictureURL { get; set; }

        //Relationships

        public List<Movie> Movies { get; set; }
    }
}
