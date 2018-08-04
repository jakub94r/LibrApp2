using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibrApp2.Models
{
    public class Book
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public DateTime? DatePublished { get; set; }
    }
}