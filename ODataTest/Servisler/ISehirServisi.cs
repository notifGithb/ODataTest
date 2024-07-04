using ODataTest.Models;

namespace ODataTest.Servisler
{
    public interface ISehirServisi
    {
        Task Olustur();
        List<Sehir> SehirleriGetir();
    }
}
