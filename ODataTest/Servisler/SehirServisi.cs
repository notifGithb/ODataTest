
using ODataTest.Models;

namespace ODataTest.Servisler
{
    public class SehirServisi
    {
        public List<Sehir> SehirleriGetir()
        {

            var sehirler = new List<Sehir>
            {
                new() {
                    Id = 1,
                    Isim = "Adana",
                    PlakaNumarasi = 1,
                    Derece = 18.5,
                    Ilceler =
                    [
                        new Ilce { Id = 1, Isim = "Seyhan", SehirId = 1, Derece = 15.2 },
                        new Ilce { Id = 2, Isim = "Çukurova", SehirId = 1, Derece = 16.8 }
                    ]
                },
                new() {
                    Id = 2,
                    Isim = "Adıyaman",
                    PlakaNumarasi = 2,
                    Derece = 21.5,
                    Ilceler =
                    [
                        new Ilce { Id = 3, Isim = "Kahta", SehirId = 2, Derece = 22 },
                        new Ilce { Id = 4, Isim = "Gölbaşı", SehirId = 2, Derece = 19.8 }
                    ]
                },
                new() {
                    Id = 3,
                    Isim = "Afyonkarahisar",
                    PlakaNumarasi = 3,
                    Derece = 12.1,
                    Ilceler =
                    [
                        new Ilce { Id = 5, Isim = "Merkez", SehirId = 3, Derece = 13.8 },
                        new Ilce { Id = 6, Isim = "Sandıklı", SehirId = 3, Derece = 10.7 }
                    ]
                },
                new() {
                    Id = 4,
                    Isim = "Ağrı",
                    PlakaNumarasi = 4,
                    Derece = 8.6,
                    Ilceler =
                    [
                        new Ilce { Id = 7, Isim = "Patnos", SehirId = 4, Derece = 7.7 },
                        new Ilce { Id = 8, Isim = "Doğubayazıt", SehirId = 4, Derece = 9.8 }
                    ]
                },
                new() {
                    Id = 5,
                    Isim = "Amasya",
                    PlakaNumarasi = 5,
                    Derece = 12.6,
                    Ilceler =
                    [
                        new Ilce { Id = 9, Isim = "Merzifon", SehirId = 5, Derece = 12.8 },
                        new Ilce { Id = 10, Isim = "Suluova", SehirId = 5, Derece = 11.6 }
                    ]
                },
                new() {
                    Id = 6,
                    Isim = "Ankara",
                    PlakaNumarasi = 6,
                    Derece = 26.2,
                    Ilceler =
                    [
                        new Ilce { Id = 11, Isim = "Çankaya", SehirId = 6, Derece = 24.9 },
                        new Ilce { Id = 12, Isim = "Keçiören", SehirId = 6, Derece = 28.1 }
                    ]
                },
                new() {
                    Id = 7,
                    Isim = "Antalya",
                    PlakaNumarasi = 7,
                    Derece = 35.4,
                    Ilceler =
                    [
                        new Ilce { Id = 13, Isim = "Alanya", SehirId = 7, Derece = 32.5 },
                        new Ilce { Id = 14, Isim = "Manavgat", SehirId = 7, Derece = 37.6 }
                    ]
                },
                new() {
                    Id = 8,
                    Isim = "Artvin",
                    PlakaNumarasi = 8,
                    Derece = 18,
                    Ilceler =
                    [
                        new Ilce { Id = 15, Isim = "Hopa", SehirId = 8, Derece = 18.6 },
                        new Ilce { Id = 16, Isim = "Arhavi", SehirId = 8, Derece = 17.2 }
                    ]
                }
            };

            return sehirler;
        }
    }
}
