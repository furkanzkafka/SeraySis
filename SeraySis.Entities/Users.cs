using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeraySis.Entities
{
    [Table("Users")]
    public class Users : EntityBase
    {
        [StringLength(25)]
        public string Name { get; set; }
        [StringLength(25)]
        public string Surname { get; set; }
        [Required, StringLength(25)]
        public string Username { get; set; }
        [Required, StringLength(70)]
        public string Email { get; set; }
        [Required, StringLength(30)]
        public string Password { get; set; }

        [StringLength(30)]
        public string ProfileImage { get; set; }

        [Required]
        public Guid ActivateGuid { get; set; }
        public bool IsActive { get; set; }
        public bool IsAdmin { get; set; }


    }
}
