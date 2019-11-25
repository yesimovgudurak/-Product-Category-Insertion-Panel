using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaregoriEklemePanali.ORM.Entity
{
    public class AppUser:BaseEntity
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        [NotMapped]//Notmapped entity içeirsinde var olamsına rağmen database'de bir tabloda bir sütün olarak oluşmayacaktır
        public string FullName
        {
            get
            {
                if (string.IsNullOrWhiteSpace(LastName))
                {
                    return FirstName;
                }
                else
                {
                    return FirstName + " " + LastName;
                }
            }
        }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        public DateTime? BirthDate { get; set; }
        public bool Gender { get; set; }
    }
}
