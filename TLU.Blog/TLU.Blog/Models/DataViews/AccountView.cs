using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLU.Blog.Models.DataViews
{
    public class AccountView
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string SurName { get; set; }
        [Required]
        public string Avatar { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        public string HomeTown { get; set; }
        public string Facebook { get; set; }
        public string Skype { get; set; }
        public Nullable<int> Gender { get; set; }
        public string Job { get; set; }
        public string Hoppy { get; set; }
    }
}
