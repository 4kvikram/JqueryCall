using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Application.DataAccessLayer.EntitieModels
{
    [Table("tblUsersDetails")]
    public class Users : CommonModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FistName { get; set; }

        public string LastName { get; set; }
        [Required]
        public string Mobile { get; set; }
        [Required]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
