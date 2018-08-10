using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibrApp2.Models
{
    public class Book
    {
        public Book()
        {
            AverageRating = 0;
            this.Reviews = new HashSet<Review>();
            this.Authors = new HashSet<Author>();
        }

        public int Id { get; set; }
        [Display(Name = "Title")]
        public String Name { get; set; }

        [Display(Name = "Date published")]
        public DateTime? DatePublished { get; set; }

        [Display(Name = "User rating")]
        public float AverageRating { get; set; }

        public Genre Genre { get; set; }
        public byte GenreId { get; set; }

        public ICollection<Review> Reviews { get; set; }

        [Display(Name = "Author")]
        public ICollection<Author> Authors { get; set; }

        [Display(Name = "Users")]
        public ICollection<UserProfile> UserProfiles { get; set; }
    }
}