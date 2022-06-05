using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OktayGulec.EntityLayer.Models
{
    [Table("Dersler")]
    public class Ders
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Ad { get; set; }
        public double Vize { get; set; }
        public double Final { get; set; }

        [NotMapped]
        public double Ortalama { get => (Vize * 0.4) + (Final * 0.6); }
        
        public int HocaId { get; set; }

        [ForeignKey("HocaId")]
        public Hoca Hoca { get; set; }

    }
}
