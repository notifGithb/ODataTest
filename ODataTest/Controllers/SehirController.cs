using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;
using ODataTest.Context;
using ODataTest.DTOs;
using ODataTest.Models;
using ODataTest.Servisler;

namespace ODataTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SehirController(ODataTestContext _context, IMapper mapper) : ControllerBase
    {

        //[HttpPost]
        //public async Task<IActionResult> Olustur()
        //{
        //    await _sehirServisi.Olustur();
        //    return Ok();
        //}


        [HttpGet]
        [EnableQuery]
        public IActionResult Get()//IQueryable ve dto döndürecek
        {
            var result = _context.Sehirler.Include(s => s.Ilceler).AsQueryable();
            return Ok(result.ProjectTo<SehirDTO>(mapper.ConfigurationProvider));
        }
    }

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
