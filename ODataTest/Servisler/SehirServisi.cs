
using ODataTest.Context;
using ODataTest.Models;

namespace ODataTest.Servisler
{
    public class SehirServisi(ODataTestContext context) : ISehirServisi
    {
        public async Task Olustur()
        {
            var sehirler = new List<Sehir>
            {
                new() {
                    Isim = "Adana",
                    PlakaNumarasi = 1,
                    Derece = 18.5,
                    Ilceler = new List<Ilce>
                    {
                        new Ilce { Isim = "Seyhan", Derece = 15.2 },
                        new Ilce { Isim = "Çukurova", Derece = 16.8 }
                    }
                },
                new() {
                    Isim = "Adıyaman",
                    PlakaNumarasi = 2,
                    Derece = 21.5,
                    Ilceler = new List<Ilce>
                    {
                        new Ilce { Isim = "Kahta", Derece = 22 },
                        new Ilce { Isim = "Gölbaşı", Derece = 19.8 }
                    }
                },
                new() {
                    Isim = "Afyonkarahisar",
                    PlakaNumarasi = 3,
                    Derece = 12.1,
                    Ilceler = new List<Ilce>
                    {
                        new Ilce { Isim = "Merkez", Derece = 13.8 },
                        new Ilce { Isim = "Sandıklı", Derece = 10.7 }
                    }
                },
                new() {
                    Isim = "Ağrı",
                    PlakaNumarasi = 4,
                    Derece = 8.6,
                    Ilceler = new List<Ilce>
                    {
                        new Ilce { Isim = "Patnos", Derece = 7.7 },
                        new Ilce { Isim = "Doğubayazıt", Derece = 9.8 }
                    }
                },
                new() {
                    Isim = "Amasya",
                    PlakaNumarasi = 5,
                    Derece = 12.6,
                    Ilceler = new List<Ilce>
                    {
                        new Ilce { Isim = "Merzifon", Derece = 12.8 },
                        new Ilce { Isim = "Suluova", Derece = 11.6 }
                    }
                },
                new() {
                    Isim = "Ankara",
                    PlakaNumarasi = 6,
                    Derece = 26.2,
                    Ilceler = new List<Ilce>
                    {
                        new Ilce { Isim = "Çankaya", Derece = 24.9 },
                        new Ilce { Isim = "Keçiören", Derece = 28.1 }
                    }
                },
                new() {
                    Isim = "Antalya",
                    PlakaNumarasi = 7,
                    Derece = 35.4,
                    Ilceler = new List<Ilce>
                    {
                        new Ilce { Isim = "Alanya", Derece = 32.5 },
                        new Ilce { Isim = "Manavgat", Derece = 37.6 }
                    }
                },
                new() {
                    Isim = "Artvin",
                    PlakaNumarasi = 8,
                    Derece = 18,
                    Ilceler = new List<Ilce>
                    {
                        new Ilce { Isim = "Hopa", Derece = 18.6 },
                        new Ilce { Isim = "Arhavi", Derece = 17.2 }
                    }
                }
            };

            await context.Sehirler.AddRangeAsync(sehirler);
            await context.SaveChangesAsync();

        }
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
