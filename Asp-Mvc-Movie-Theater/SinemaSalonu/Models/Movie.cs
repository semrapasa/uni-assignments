using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SinemaSalonu.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Film Adı")]
        public string Title { get; set; }

        [Display(Name = "Tür")]
        public string Genre { get; set; }

        [System.Web.Mvc.AllowHtml]
        [Display(Name = "Açıklama")]
        public string Description { get; set; }

        [Display(Name = "Kapak Resmi URL")]
        public string ImageUrl { get; set; }

        [Display(Name = "Vizyon Tarihi")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "SEO Link")]
        public string SeoUrl { get; set; }
    }
}
