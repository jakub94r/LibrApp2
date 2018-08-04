using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibrApp2.Models
{
    public class Genre
    {
        public byte Id { get; set; }

        [Display(Name = "Genre")]
        public String Name { get; set; }
    }
}