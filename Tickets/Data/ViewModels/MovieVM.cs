using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tickets.Data;
using Tickets.Data.Base;

namespace Tickets.Models
{
    public class MovieVM
    {
        public int Id { get; set; }


        [Required(ErrorMessage ="Name is required")]
        [Display(Name ="Movie Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [Display(Name = "Movie Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Display(Name = "Price in $")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Poster URL is required.")]
        [Display(Name = "Movie Poster URL")]
        public string ImageURL { get; set; }

        [Required(ErrorMessage = "Start date is required")]
        [Display(Name = "Start date")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End date is required")]
        [Display(Name = "End date")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Movie category is required")]
        [Display(Name = "Select a category")]
        public MovieCategory MovieCategory { get; set; }


        [Required(ErrorMessage = "Actor(s) is required")]
        [Display(Name = "Select Actor(s)")]
        public List<int> ActorIds { get; set; }

        [Required(ErrorMessage = "Cinema is required")]
        [Display(Name = "Select cinema")]
        public int CinemaId { get; set; }

        [Required(ErrorMessage = "Producer is required")]
        [Display(Name = "Select producer")]
        public int ProducerId { get; set; }


    }
}
