using System;
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
    public class Charts1Controller : ControllerBase
    {
        private readonly DBITCompanyContext _context;

        public Charts1Controller(DBITCompanyContext context)
        {
            _context = context;
        }

        [HttpGet("JsonData1")]

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
    }
}