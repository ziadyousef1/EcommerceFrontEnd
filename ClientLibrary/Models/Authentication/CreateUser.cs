using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientLibrary.Models.Authentication
{
    public class CreateUser: AuthenticationBase
    {
     [Required,Compare(nameof(ConfirmPassword))]
        public string ConfirmPassword { get; set; }
        [Required]
        public string FullName { get; set; }
    }
}
