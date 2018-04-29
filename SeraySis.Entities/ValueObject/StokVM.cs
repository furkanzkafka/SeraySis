using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeraySis.Entities.ValueObject
{
    public class StokVM
    {
        [DisplayName("Malzeme Tanım"), Required(ErrorMessage = "{0} alanı boş geçilemez.."), StringLength(120, ErrorMessage = "{0} En Fazla {1} Karakter Olabilir.")]
        public string MalzemeTanim { get; set; }

        [DisplayName("Kdv Oran"), Required(ErrorMessage = "{0} alanı boş geçilemez.."), Range(0, 100, ErrorMessage = "Kdv 0'dan küçük 100'den büyük olamaz.")]
        public string KdvOran { get; set; }

        [DisplayName("BirimFiyat"), Required(ErrorMessage = "{0} alanı boş geçilemez.."), Range(0.0, Double.MaxValue,ErrorMessage = "Birim Fiyat 0'dan küçük olamaz")]
        public string BirimFiyat { get; set; }

        [DisplayName("Birim Para"), Required(ErrorMessage = "{0} alanı boş geçilemez..")]
        public string BirimPara { get; set; }

        public string Kod { get; set; }
    }
}
