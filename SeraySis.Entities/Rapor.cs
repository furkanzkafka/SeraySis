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
    [Table("Rapor")]
    public class Rapor : EntityBase
    {
        public int FaturaKod { get; set; }

        [DisplayName("Firma Adı"), Required(ErrorMessage = "{0} alanı boş geçilemez.."), StringLength(120, ErrorMessage = "{0} En Fazla {1} Karakter Olabilir.")]
        public string FirmaAdi { get; set; }

        [DisplayName("Fatura Tarih"), Required(ErrorMessage = "{0} alanı boş geçilemez..")]
        public DateTime FaturaTarih { get; set; }

        [DisplayName("Adres"), StringLength(200, ErrorMessage = "{0} En Fazla {1} Karakter Olabilir.")]
        public string Adres { get; set; }

        [DisplayName("Vergi No"), StringLength(120, ErrorMessage = "{0} En Fazla {1} Karakter Olabilir.")]
        public string VergiNo { get; set; }

        [DisplayName("Vergi Dairesi"), StringLength(120, ErrorMessage = "{0} " +
            "En Fazla {1} Karakter Olabilir.")]
        public string VergiDairesi { get; set; }

        [DisplayName("Miktar Litre"), Required(ErrorMessage = "{0} alanı boş geçilemez.."), Range(0.0, Double.MaxValue, ErrorMessage = "{0} 0'dan küçük olamaz")]
        public double MiktarLitre { get; set; }

        [DisplayName("Net Tutar"), Required(ErrorMessage = "{0} alanı boş geçilemez.."), Range(0.0, Double.MaxValue, ErrorMessage = "{0} 0'dan küçük olamaz")]
        public double NetTutar { get; set; }

        [DisplayName("KDV"), Required(ErrorMessage = "{0} alanı boş geçilemez.."), Range(0.0, Double.MaxValue, ErrorMessage = "{0} 0'dan küçük olamaz")]
        public double KdvliTutar { get; set; }

        [DisplayName("Toplam Tutar"), Required(ErrorMessage = "{0} alanı boş geçilemez.."), Range(0.0, Double.MaxValue, ErrorMessage = "{0} 0'dan küçük olamaz")]
        public double ToplamTutar { get; set; }

        public int StokkartId { get; set; }

        public virtual StokKart StokKart { get; set; }

    }
}
