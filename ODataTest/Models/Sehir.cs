namespace ODataTest.Models
{
    public class Sehir
    {
        public int Id { get; set; }
        public required string Isim { get; set; }
        public int PlakaNumarasi { get; set; }
        public double Derece { get; set; }

        public List<Ilce> Ilceler { get; set; } = new List<Ilce>();

    }
}
