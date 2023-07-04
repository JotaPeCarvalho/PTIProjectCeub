using System.ComponentModel.DataAnnotations;

namespace WebProjectPTI.Models
{
    public class LoginModel
    {
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "É necessário informar o login")]
        public string UserName { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "É necessário informar a senha")]
        public string Password { get; set; }
    }
}
