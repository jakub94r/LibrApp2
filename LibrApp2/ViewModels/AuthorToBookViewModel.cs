using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibrApp2.Models;

namespace LibrApp2.ViewModels
{
    public class AuthorToBookViewModel
    {
        public List<Author> AuthorsList { get; set; }
        public List<Author> AlreadyAuthors { get; set; }
        public int BookId { get; set; }
    }
}