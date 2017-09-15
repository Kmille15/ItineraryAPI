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
    public class UserGuides
    {
        [Key]
        public int UserGuideId { get; set; }
        public User User { get; set; }
        public Guides Guides { get; set; }
        [Required]
        public int GuideId { get; set; }



    }
}
