using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using ItineraryAPI.Models;



namespace ItineraryAPI.Models
{
    public class Guides
    {
        [Key]
        public int GuideId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public string MainImage { get; set; }

        public virtual ICollection<UserGuides> UserGuides { get; set; }
    }
}
