using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class BlogModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Author { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime LastEditTime { get; set; }
        public string Tag { get; set; }
        public string Category { get; set; }
        public string MainBody { get; set; }
        public int? ViewCount { get; set; }
        public int IsPrivate { get; set; }
    }
}
