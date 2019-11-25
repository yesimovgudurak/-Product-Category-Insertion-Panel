using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaregoriEklemePanali.ORM.Entity
{
    [Table("Categories")]//Table attribute içerisine yazılmış olan string değer tablo oluşturulurken tablo ismi oalrak belirlenecektir
    public class Category:BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string CategoryName { get; set; }
        public string Description { get; set; }

        public List<Product> Products { get; set; }//Mapping
    }
}
