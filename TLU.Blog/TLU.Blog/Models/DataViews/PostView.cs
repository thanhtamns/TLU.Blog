using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLU.Blog.Models.DataViews
{
    public class PostView
    {
        [Required]
        public string pDescrip { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string pContent { get; set; }
        [Required]
        public string pNameTopic { get; set; }
    }
}
