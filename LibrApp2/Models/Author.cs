using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibrApp2.Models
{
    public class Author
    {
        public Author()
        {
            this.Books = new HashSet<Book>();
        }

        public int Id { get; set; }
        public String FullName { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}