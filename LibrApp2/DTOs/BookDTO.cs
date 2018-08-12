using LibrApp2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace LibrApp2.DTOs
{
    public class BookDTO
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter book's title")]
        [StringLength(255, ErrorMessage = "Title can have maximum of {1} characters")]
        public String Name { get; set; }

        public DateTime? DatePublished { get; set; }

        public float AverageRating { get; set; }

        public String Genre { get; set; }
        public byte GenreId { get; set; }

        public List<ReviewDTO> ReviewsDTOs { get; set; }

        public ICollection<String> AuthorFullNames { get; set; }

        public List<int> UserProfileIds { get; set; }
        public ICollection<String> UserProfileUsernames { get; set; }
    }
}