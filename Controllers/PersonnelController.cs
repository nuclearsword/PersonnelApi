using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PersonnelApi.Models;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;

namespace PersonnelApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonnelController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> Get(){
            using(var ctx = new KDTestContext()){
                return await ctx.Personnel.ToListAsync();
            }
        }
    }
}