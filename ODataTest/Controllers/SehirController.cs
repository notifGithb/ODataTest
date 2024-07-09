using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using ODataTest.Context;
using ODataTest.DTOs;
using ODataTest.Servisler;

namespace ODataTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SehirController(ISehirServisi _sehirServisi, ODataTestContext _context, IMapper mapper) : ODataController
    {

        [HttpPost]
        public async Task<IActionResult> Olustur()
        {
            await _sehirServisi.Olustur();
            return Ok();
        }


        [HttpGet]
        [EnableQuery]
        public IActionResult Get()
        {
            //var result = _context.Sehirler.AsQueryable();
            IQueryable<SehirDTO> result = _context.Sehirler
                .Select(s => new SehirDTO
                {
                    Isim = s.Isim,
                    PlakaNumarasi = s.PlakaNumarasi,
                    Derece = s.Derece,
                    Ilceler = s.Ilceler.Select(i => new IlceDTO
                    {
                        Isim = i.Isim,
                        Derece = i.Derece,
                        SehirId = i.SehirId
                    }).ToList()
                }).AsQueryable();

            return Ok(result);
        }
    }

    #region http://localhost:5141/api/Sehir?$expand=Ilceler

    #endregion

    #region http://localhost:5141/api/Sehir?$expand=Ilceler($select=isim)&pageNumber=1&pageSize=1

    #endregion

    #region http://localhost:5141/api/Sehir?$filter=Id eq 1&$expand=Ilceler($filter=Id gt 1;$select=isim)
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

    #region http://localhost:5141/api/Sehir?$select=Isim&$expand=Ilceler($filter=Derece gt 16;$select=isim,derece)
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
