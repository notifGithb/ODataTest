namespace ODataTest.Models
{
    public class Ilce
    {
        public int Id { get; set; }
        public required string Isim { get; set; }
        public double Derece { get; set; }

        public int SehirId { get; set; }

        public Sehir Sehir { get; set; }
    }
}
