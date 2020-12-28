using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarDatabase.Data;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarsDatabase.Api.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowOrigin")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ApplicationDbContext Context;
        public CarsController(ApplicationDbContext context)
        {
            Context = context;
        }

        // GET: api/<CarsController>
        [HttpGet]
        public IEnumerable<Car> Get()
        {
            return Context.Cars;
        }

        // GET api/<CarsController>/5
        [HttpGet("{id}")]
        public Car Get(int id)
        {
            return Context.Cars.SingleOrDefault(x => x.Id == id);
        }

        // POST api/<CarsController>
        [HttpPost]
        public void Post([FromBody]Car car)
        {
            Context.Add(car);
            Context.SaveChanges();
        }

        // PUT api/<CarsController>/5
        [HttpPut]
        public void Put([FromBody] Car model)
        {
            var car = Context.Cars.Single(x => x.Id == model.Id);
            car.Color = model.Color;
            car.EngineSizeInCC = model.EngineSizeInCC;
            car.IsElectric = model.IsElectric;
            car.Make = model.Make;
            car.Model = model.Model;
            car.PlateNumber = model.PlateNumber;

            Context.SaveChanges();
        }

        // DELETE api/<CarsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var car = Context.Cars.Single(x => x.Id == id);
            Context.Remove(car);
            Context.SaveChanges();
        }
    }
}
