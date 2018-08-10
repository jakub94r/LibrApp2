using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LibrApp2.Models
{
    public class UserProfile
    {
        public UserProfile()
        {
            this.Reviews = new HashSet<Review>();
            Books = new HashSet<Book>();
        }

        public int Id { get; set; }


        [Display(Name = "User")]
        public string Username { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Book> Books { get; set; }

        public virtual ApplicationUser AspNetUser { get; set; }
        public string AspNetUserId { get; set; }
    }
}