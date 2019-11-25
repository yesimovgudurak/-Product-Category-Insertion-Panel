using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaregoriEklemePanali.ORM.Entity
{
    //Buraya bütün tablolarımda ortak olan property lari yazıyoruz. Bütün classlarım bu clasdan miras alacak. Migrations yaptığımızda BaseEntity db'de bir tablo olrak teşekkül etmeyecek
    public class BaseEntity
    {
        /*EntityFarmework Default olarak ID alanını Primary Key olarak belirler ve identity olarak işaretler, fakat manuel olarak bunu yapmak istediğimizde alttaki attribute'leri kullanabiliriz*/
        [Key]//using System.ComponentModel.DataAnnotations eklenir.
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//using System.ComponentModel.DataAnnotations.Schema
        public int ID { get; set; }

        //Aşağıd akullandığımız soru işaretinin "?" anlamı db tarafında bu prop'un boş geçilmesini anlamına gelmektedir. 
        private DateTime? _addDate = DateTime.Now;
        public DateTime? AddDate { get { return _addDate; } set { _addDate = value; } }

        /*Encapsulation: Nesnenin üyelerine yapılan erişimin kontrol altına alınmasına ve bu kontrolün nesnenin kendisi tarafından yapılmasını sağlamaktır. Amaç fiedl'ları private yaparak bu alanlara dışarıdan erişimi önlemek ve get-set metotları ile kontrolü sağlamaktır. */

        private DateTime? _updateDate = DateTime.Now;// _updateDate değişkenimize dışarıdan erişimi kapadık.
        public DateTime? UpdateDate//_updateDate Fİeld'ımıza dışarıdan erişilmeyecek fakat Field'dan türetilen UpdateDate isimli Property ile dışarıdan haberleşip Fİeld'dan veri alıp dışarıya atacak, dışarıdaki değeri alarak Fİeld'a atacak.
        {
            get { return _updateDate; }//Field'daki değeri dışarıya gönderir
            set { _updateDate = value; }//Dışiarıdan alınan değer, Field'a atar.
        }

        [Column(Order = 3, TypeName = "datetime2")]//Column ile database'de sütun sırasını ve veritiplerini belirleyebilrisiniz belirtebilirsiniz.
        private DateTime? _deletedDate = DateTime.Now;
        public DateTime? DeletedDate { get { return _deletedDate; } set { _deletedDate = value; } }

        private bool _isDeleted = false;
        public bool IsDeleted { get { return _isDeleted; } set { _isDeleted = value; } }



    }
}
