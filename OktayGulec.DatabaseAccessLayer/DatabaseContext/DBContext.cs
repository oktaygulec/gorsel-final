using OktayGulec.EntityLayer.Models;
using System.Data.Entity;

namespace OktayGulec.DatabaseAccessLayer.DatabaseContext
{
    public class DBContext : DbContext
    {
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Hoca> Hocalar { get; set; }
        public DbSet<Ders> Dersler { get; set; }

        public DBContext() : base("name=DbConnectionString")
        {
            Database.SetInitializer(new CustomInitializer());
        }
    }

    public class CustomInitializer : CreateDatabaseIfNotExists<DBContext>
    {
        protected override void Seed(DBContext context)
        {
            context.Kullanicilar.Add(new Kullanici { EPosta = "user1@gmail.com", Parola = "1234" });
            context.Kullanicilar.Add(new Kullanici { EPosta = "deneme@gmail.com", Parola = "1234" });

            var ademOkumus = new Hoca { Ad = "Adem", Soyad = "Okumuş" };
            var kemalettin = new Hoca { Ad = "Kemalettin", Soyad = "Kamiloğlu" };
            var deneme = new Hoca { Ad = "Deneme", Soyad = "Denemeoğlu" };
            context.Hocalar.Add(ademOkumus);
            context.Hocalar.Add(kemalettin);
            context.Hocalar.Add(deneme);

            context.Dersler.Add(new Ders { Ad = "Deneme Ders", Hoca = ademOkumus, Vize = 100, Final = 34 });
            context.Dersler.Add(new Ders { Ad = "asd", Hoca = kemalettin, Vize = 34, Final = 40 });
            context.Dersler.Add(new Ders { Ad = "Deneme ders", Hoca = deneme, Vize = 60, Final = 50 });

            context.SaveChanges();

            base.Seed(context);
        }
    }
}
