using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bictly.Models
{
    public class User
    {
        public int id { get; set; }
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public bool IsAdmin { get; set; } = false;
        [Required]
        public DateTime reg_date { get; set; } = DateTime.Now;
        [Required]
        public string token { get; set; }
        public List<Article> Articles { get; set; }
        public List<Comment> Comment { get; set; }
    }
}
