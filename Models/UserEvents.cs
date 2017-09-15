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
    public class UserEvents
    {
        [Key]
        public int UserEventId { get; set; }
        public User User { get; set; }
        [Required]
        public int EventId { get; set; }
        public Events Events { get; set; }




    }
}
