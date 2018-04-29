using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SeraySis.Entities.ValueObjects
{
    public class RegisterVM
    {
        [DisplayName("Kullanici Adı"),
            Required(ErrorMessage = "{0} alanı boş geçilemez.."),
            StringLength(25, ErrorMessage = "{0} En Fazla {1} Karakter Olabilir.")]
        public string Username { get; set; }

        [DisplayName("E-Posta"),
            Required(ErrorMessage = "{0} alanı boş geçilemez.."),
            StringLength(70, ErrorMessage = "{0} En Fazla {1} Karakter Olabilir."),
            DataType(DataType.Password),
            EmailAddress(ErrorMessage = "{0} alanı için geçerli bir E-Posta adresi girmelisiniz")]
        public string Email { get; set; }

        [DisplayName("Şifre"),
            Required(ErrorMessage = "{0} alanı boş geçilemez.."),
            StringLength(25, ErrorMessage = "{0} En Fazla {1} Karakter Olabilir."),
            DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Şifre Tekrar"),
            Required(ErrorMessage = "{0} alanı boş geçilemez.."),
            StringLength(25, ErrorMessage = "{0} En Fazla {1} Karakter Olabilir."),
            DataType(DataType.Password), Compare("Password", ErrorMessage = "{0} , {1} ile uyuşmuyor")]
        public string RePassword { get; set; }
    }
}