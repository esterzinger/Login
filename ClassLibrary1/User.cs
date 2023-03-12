using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class User
    {

            public int? Id { get; set; }

            public int? Age { get; set; }
            public string? Name { get; set; }

            [StringLength(20, ErrorMessage = "name between o- 20 char")]
            public string Password { get; set; }
            public string Email { get; set; }


        }
 }
