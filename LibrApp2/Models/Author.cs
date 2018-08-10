using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please enter author's name")]
        [StringLength(50, ErrorMessage = "Name can have maximum of {1} characters")]
        public String FullName { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}