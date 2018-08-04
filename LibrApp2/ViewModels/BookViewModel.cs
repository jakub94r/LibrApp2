using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibrApp2.Models;

namespace LibrApp2.ViewModels
{
    public class BookViewModel
    {
        public Book Book { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
    }
}