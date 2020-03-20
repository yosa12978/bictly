using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace bictly.Models
{
    public class Article
    {
        public int id { get; set; }
        [Required]
        public string title { get; set; }
        public string description { get; set; }
        [Required]
        public string text { get; set; }
        [Required]
        public long popularity { get; set; } = 0;
        [Required]
        public DateTime date { get; set; } = DateTime.Now;
        [Required]
        public User Author { get; set; }
    }
}
