using System.ComponentModel.DataAnnotations;

namespace ClientLibrary.Models.Authentication
{
    public class AuthenticationBase
    {

        public  string Email { get; set; }
       
        public  string Password { get; set; }
    }
}
