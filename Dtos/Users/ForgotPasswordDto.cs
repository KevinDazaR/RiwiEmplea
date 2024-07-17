using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RiwiEmplea.Dtos.Users
{
    public class ForgotPasswordDto
    {
        [Required(ErrorMessage = "This field is necessary")]
        public string? Email { get; set; } // <---- ---->
    }
}