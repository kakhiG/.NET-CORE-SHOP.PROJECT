using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.UI.ViewModels.Admin
{
    public class CreateUserViewModel
    {
        [Required]
        public string  Username { get; set; }
        public string  Password { get; set; }
    }
}
