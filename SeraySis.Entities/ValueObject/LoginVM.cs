using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SeraySis.Entities.ValueObjects
{
    public class LoginVM
    {
        [DisplayName("Kullanici Adı"), Required(ErrorMessage = "{0} alanı boş geçilemez.."), StringLength(25, ErrorMessage = "{0} En Fazla {1} Karakter Olabilir.")]
        public string Username { get; set; }

        [DisplayName("Şifre"), Required(ErrorMessage = "{0} alanı boş geçilemez.."), StringLength(25, ErrorMessage = "{0} En Fazla {1} Karakter Olabilir."), DataType(DataType.Password)]
        public string Password { get; set; }
    }
}