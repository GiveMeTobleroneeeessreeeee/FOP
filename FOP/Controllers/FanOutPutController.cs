using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FOPClassLibrary;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FOPRestApi.Controllers
{
    [Route("Fanoutputs")]
    [ApiController]
    public class FanOutPutController : ControllerBase
    {
        private static readonly List<FanOutPut> fanOutPuts = new List<FanOutPut>()
        {
            new FanOutPut(1, 55.32, 23.2, "Omklædningsrum"),
            new FanOutPut(2, 45, 21, "Indgang"),
            new FanOutPut(3, 42, 16, "Kontor"),
            new FanOutPut(4, 43.23, 15.3, "Gymnastiksal"),
            new FanOutPut(5, 45.24, 16.53, "Klasseværelse 001"),
            new FanOutPut(6, 76.34, 24.3, "Klasseværelse 002"),
            new FanOutPut(7, 76.99, 19.2, "Klasseværelse 003")
            

        };

        // GET: api/<FanOutPutsController>
        [HttpGet]
        public IEnumerable<FanOutPut> Get()
        {
            return fanOutPuts;
        }

        // GET api/Fanoutputs/Navn/theRequestedSubstring
        [HttpGet]
        [Route("Navn/{substring}")]
        public IEnumerable<FanOutPut> GetFromSubstring(String substring)
        {
            return fanOutPuts.FindAll(i => i.Navn.Contains(substring));
        }

        // GET api/<FanOutPutsController>/5
        [HttpGet]
        [Route("{id}")]
        public FanOutPut Get(int id)
        {
            return fanOutPuts.Find(fop => fop.Id == id);
        }


        // POST api/<FanOutPutsController>
        [HttpPost]
        public void Post([FromBody] FanOutPut value)
        {

            var fopitem = fanOutPuts.Last();

            if (value.Id == fopitem.Id+1)
            {
                fanOutPuts.Add(value);
            }
            else
            {
                value.Id = fopitem.Id + 1;
                fanOutPuts.Add(value);
            }

        }

        // PUT api/<FanOutPutsController>/5
        [HttpPut("{id}")]
        [Route("{id}")]
        public void Put(int id, [FromBody] FanOutPut value)
        {
            FanOutPut fanOutPut = Get(id);
            if(fanOutPut!=null)
            {
                fanOutPut.Id = value.Id;
                fanOutPut.Fugt = value.Fugt;
                fanOutPut.Temp = value.Temp; 
                fanOutPut.Navn = value.Navn;
            }
        }

        // DELETE api/<FanOutPutsController>/5
        [HttpDelete("{id}")]
        [Route("{id}")]
        public void Delete(int id)
        {
            FanOutPut fanOutPut = Get(id);
            fanOutPuts.Remove(fanOutPut);
        }

        
    }
}
