﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace LibrApp2.Models
{
    [Serializable]
    [DataContract(IsReference = true)]
    public class Review
    {
        public int Id { get; set; }

        [StringLength(255)]
        [Display(Name = "Review")]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        [Required(ErrorMessage = "Please give the book a grade")]
        [Range(1, 10, ErrorMessage = "Please enter a value between {1} and {2}")]
        public byte Rate { get; set; }

        public int BookId { get; set; }
        public int UserProfileId { get; set; }

        public virtual Book Book { get; set; }
        public virtual UserProfile UserProfile { get; set; }
    }
}