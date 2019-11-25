using KaregoriEklemePanali.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaregoriEklemePanali.ORM.Context
{
    public class ProjectContext:DbContext
    {
        /*
        Adım Adım CodeFirst
        1-)Nuget Package Manager ile Entity Framework projeye eklenir.
        2-)Proje büyüklüğüne göre DAL (Data Access Layer) katmanı yada klasörü açılır.
        3-)Dal katanı yada klasörü içerisine ORM (Object Relation Mapping) klasörü açılır.
        4-)ORM altına Context ve Entity klasörleri açılır
        5-)Entity kalsörü altına tablo olacak olan class'lar yazılır.
        6-)Conctext altına ise ProjectContext class'ı eklenir
        7-)ProjectContext Class'ı DbContext'ten (System.Data.Entity) miras alır
        8-)Tablo olmasını istediğimiz classlar "public DbSet<> Entities {get;set;}" formatında yazılır.
        9-)NuGet Console açılarak "enable-migrations -enableautomaticmigrations" yazılır(Eğer -EnableAutomaticMigrations yapmazsanız migrations sonrasında açılan configuration classında "false" kısmını "true" yapınız)
        10-)Açık olan console ekranında Update-Database işlemini yapınız.        
        */
        public ProjectContext()
        {
            Database.Connection.ConnectionString = "Server=.;Database=AddCategory;uid=sa;pwd=1234;";
            //Database'de ismi yeni oluşacak veritabanı ismi verilir.
        }

        //BaseEntity dbset olmak zorunda değildir.

        //DbSet sınıfı create,read,update ve delte işlemlerinde kullanılan entitiy setlerini temsil eder.
        public DbSet<AppUser> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        /*Hali hazırda kullanılan database yerine farkllı bir database migrations yapmak istediğimizde solution altında bulunan Migrations klasörü silinir. Migrations yapmak için gerekli consoole kodu yazdıktan sonra Bize aşağıda yazılı olan hatayı verecektir. Migrations have already been enabled in project 'CodeFirstLogin'. To overwrite the existing migrations configuration, use the -Force parameter.*/
    }
}
