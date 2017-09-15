using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using ItineraryAPI.Models;
using Microsoft.AspNetCore.Identity;


namespace ItineraryAPI.Models
{
    public class User : IdentityUser
    {
        
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
 

        public virtual ICollection<UserEvents> UserEvents { get; set; }
        public virtual ICollection<UserGuides> UserGuides { get; set; }



    }
}
