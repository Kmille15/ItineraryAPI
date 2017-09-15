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
    public class Events
    {
        [Key]
        public int EventId { get; set; }
        [Required]
        public string Title { get; set; }
       // [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string MainImage { get; set; }
        public string TicketLink { get; set; }

        public bool PremiumContent { get; set; }
        public string PremiumImage { get; set; }
        public virtual ICollection<UserEvents> UserEvents { get; set; }

    }
}
