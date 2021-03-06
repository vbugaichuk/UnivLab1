﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DBIT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartsController : ControllerBase
    {
        private readonly DBITCompanyContext _context;

        public ChartsController(DBITCompanyContext context)
        {
            _context = context;
        }


        [HttpGet("JsonData")]
        

        
        public JsonResult JsonData()
        {
            var countries = _context.Countries.Include(b => b.Cities).ToList();
            List<object> cCity = new List<object>();
            cCity.Add(new object[] { "Країна", "Кількість міст" });
            foreach (var c in countries)
            {
                cCity.Add(new object[] { c.Name, c.Cities.Count() });

            }
            return new JsonResult(cCity);
        }
        

            /*
        public JsonResult JsonData1()
        {
            var cities = _context.Cities.Include(b => b.Offices).ToList();
            List<object> cIT = new List<object>();
            cIT.Add(new object[] { "Місто", "Кількість офісів" });
            foreach (var c in cities)
            {
                cIT.Add(new object[] { c.Name, c.Offices.Count() });
            }
            return new JsonResult(cIT);
        }
        */


    }
}