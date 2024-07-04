namespace ODataTest.DTOs
{
    public class SehirDTO
    {
        public int Id { get; set; }
        public required string Isim { get; set; }
        public int PlakaNumarasi { get; set; }
        public double Derece { get; set; }
        public ICollection<IlceDTO> Ilceler { get; set; } = [];
    }
}
