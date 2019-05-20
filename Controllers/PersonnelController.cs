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

        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> Get(int id){
            using(var ctx = new KDTestContext()){
                return await ctx.Personnel.FirstAsync(m => m.PersonID == id);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Person>> Post(Person person){
            using(var ctx = new KDTestContext()){
                ctx.Personnel.Add(person);
                await ctx.SaveChangesAsync();

                return CreatedAtAction(nameof(Person), new { id = person.PersonID }, person);
            }
        }
    }
}