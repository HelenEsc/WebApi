using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class Book
    {
        [Required]
        public int id { get; set; }
        [Required]
        public string title { get; set; }
        public string description { get; set; }
        public decimal pageCount { get; set; }
        [Required]
        public string excerpt { get; set; }
        public string publishDate { get; set; }

    }
}