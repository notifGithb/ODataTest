using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using ODataTest.Models;
using ODataTest.Servisler;

namespace ODataTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SehirController : ControllerBase
    {
        private readonly SehirServisi _sehirServisi;

        public SehirController()
        {
            _sehirServisi = new SehirServisi();
        }

        //[HttpGet]
        //public ActionResult<IEnumerable<Sehir>> Gets()
        //{
        //    var cities = _sehirServisi.SehirleriGetir();
        //    return Ok(cities);
        //}


        [HttpGet]
        [EnableQuery]
        public ActionResult Get()
        {
            var result = _sehirServisi.SehirleriGetir();

            return Ok(result);
        }
    }

    #region Sehirin Id si 1 den büyük olan ilçeleri getir
    //    "http://localhost:5141/api/Sehir?$filter=Id eq 1&$expand=Ilceler($filter=Id gt 1;$select=isim)"

    //        {
    //    "$id": "1",
    //    "$values": [
    //        {
    //            "$id": "1",
    //            "Ilceler": {
    //                "$id": "2",
    //                "$values": [
    //                    {
    //                        "$id": "1",
    //                        "Isim": "Çukurova"
    //                    }
    //                ]
    //            },
    //            "Id": 1,
    //            "Isim": "Adana",
    //            "PlakaNumarasi": 1
    //        }
    //    ]
    //}
    #endregion

    #region http://localhost:5141/api/Sehir?$select=Id,Isim&$expand=Ilceler($filter=Derece gt 16;$select=isim,derece)
    //{
    //"$id": "1",
    //"$values": [
    //    {
    //        "$id": "1",
    //        "Ilceler": {
    //            "$id": "2",
    //            "$values": [
    //                {
    //                    "$id": "1",
    //                    "Isim": "Çukurova",
    //                    "Derece": 16.8
    //                }
    //            ]
    //        },
    //        "Id": 1,
    //        "Isim": "Adana"
    //    },
    //    {
    //"$id": "1",
    //        "Ilceler": {
    //    "$id": "2",
    //            "$values": [
    //                {
    //        "$id": "1",
    //                    "Isim": "Kahta",
    //                    "Derece": 22
    //                },
    //                {
    //        "$id": "1",
    //                    "Isim": "Gölbaşı",
    //                    "Derece": 19.8
    //                }
    //            ]
    //        },
    //        "Id": 2,
    //        "Isim": "Adıyaman"
    //    }
    //]
    //}
    #endregion

}
