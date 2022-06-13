
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Application.Models
{
    public class RegistrationModel
    {
        public int Id { get; set; }
        [Required]
        public string FistName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string Mobile { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
