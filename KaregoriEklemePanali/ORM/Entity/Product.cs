using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaregoriEklemePanali.ORM.Entity
{
    public class Product:BaseEntity
    {
        [Required]
        public string ProductName { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitInStock { get; set; }


        //Sonuna ID koyduğumuz bu kolon otomatik oalrak PK olarka algılanmaktadır
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }//Mapping
    }

}
