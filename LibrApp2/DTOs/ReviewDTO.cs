using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibrApp2.DTOs
{
    public class ReviewDTO
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string Content { get; set; }

        [Required(ErrorMessage = "Please give the book a grade")]
        [Range(1, 10, ErrorMessage = "Please enter a value between {1} and {2}")]
        public byte Rate { get; set; }

        public int BookId { get; set; }
        public int UserProfileId { get; set; }

        public virtual String BookName { get; set; }
        public virtual String UserProfileUsername { get; set; }
    }
}