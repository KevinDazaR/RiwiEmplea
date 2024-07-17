    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    namespace RiwiEmplea.Dtos.Users
    {
        public class UsersDTO
        {
            [Required(ErrorMessage = "This field is necessary")]
            public string? Name { get; set; }

            // [Required(ErrorMessage = "This field is necessary")]
            // public string ? LastName { get; set; }

            [Required(ErrorMessage = "This field is necessary")]
            public string? Email { get; set; }

            [Required(ErrorMessage = "This field is necessary")]
            public string? Password { get; set; }

            [Required(ErrorMessage = "This field is necessary")]
            public string? ConfirmPassword { get; set; }

            [Required(ErrorMessage = "This field is necessary")]
            [ForeignKey ("Roles")]
            public int? RoleId { get; set; }

        

        }
    }


