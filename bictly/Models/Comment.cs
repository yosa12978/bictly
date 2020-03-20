using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bictly.Models
{
    public class Comment
    {
        public int id { get; set; }
        [Required]
        public string text { get; set; }
        [Required]
        public int articleId { get; set; }
        [Required]
        public DateTime date { get; set; } = DateTime.Now;
        [Required]
        public User author { get; set; }
    }
}
