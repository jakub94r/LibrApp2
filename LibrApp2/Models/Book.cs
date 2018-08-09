using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibrApp2.Models
{
    public class Book
    {
        public Book()
        {
            this.Reviews = new HashSet<Review>();
            this.Authors = new HashSet<Author>();
        }

        public int Id { get; set; }
        public String Name { get; set; }
        public DateTime? DatePublished { get; set; }
        public Genre Genre { get; set; }
        public byte GenreId { get; set; }

        public ICollection<Review> Reviews { get; set; }
        public ICollection<Author> Authors { get; set; }
    }
}