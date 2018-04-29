using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeraySis.Entities
{
    [Table("StokKart")]
    public class StokKart : EntityBase
    {
        [DisplayName("Malzeme Tanım"), Required(ErrorMessage = "{0} alanı boş geçilemez.."), StringLength(120, ErrorMessage = "{0} En Fazla {1} Karakter Olabilir.")]
        public string MalzemeTanim { get; set; }

        public int Kod { get; set; }

        [DisplayName("Kdv Oran"), Required(ErrorMessage = "{0} alanı boş geçilemez.."), Range(0, 100, ErrorMessage = "Kdv 0'dan küçük 100'den büyük olamaz.")]
        public double KdvOran { get; set; }

        [DisplayName("Birim Fiyat"), Required(ErrorMessage = "{0} alanı boş geçilemez.."), Range(0.0, Double.MaxValue, ErrorMessage = "Birim Fiyat 0'dan küçük olamaz")]
        public double BirimFiyat { get; set; }

        [DisplayName("Birim Para"), Required(ErrorMessage = "{0} alanı boş geçilemez.."),DataType(DataType.Currency)]
        public string BirimPara { get; set; }

        public virtual List<Rapor> Rapors { get; set; }

        public StokKart()
        {
            Rapors = new List<Rapor>();
        }

    }
}
