using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OktayGulec.EntityLayer.Models
{
    [Table("Hocalar")]
    public class Hoca
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        
        [NotMapped]
        public string AdSoyad { get => Ad + " " + Soyad; }
    }
}
