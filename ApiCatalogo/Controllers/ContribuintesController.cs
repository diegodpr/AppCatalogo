using ApiCatalogo.Context;
using ApiCatalogo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogo.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ContribuintesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ContribuintesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "contribuintes")]
        public ActionResult<IEnumerable<Contribuinte>> Get()
        {

            return _context.Contribuintes.AsNoTracking().ToList();

        }

        [HttpGet("{id}")]
        public ActionResult<Contribuinte> GetId(int id)
        {
            var contribuinte = _context.Contribuintes.FirstOrDefault(c => c.Id == id);
            if (contribuinte == null)
            {
                return NotFound();
            }
            return contribuinte;
        }


        [HttpPost]
        public ActionResult Post([FromBody]Contribuinte contribuinte)
        {
            _context.Contribuintes.Add(contribuinte);
            _context.SaveChanges();

            return new CreatedAtRouteResult("contribuintes", contribuinte);
        }


        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Contribuinte contribuinte)
        {

            _context.Entry(contribuinte).State = EntityState.Modified;
            _context.SaveChanges();
            return new CreatedAtRouteResult("Contribuinte", contribuinte);
        }

        [HttpDelete("{id}")]
        public  ActionResult Delete(int id)
        {
           var contribuinte = _context.Contribuintes.FirstOrDefault(c => c.Id == id);
            _context.Remove(contribuinte);
            _context.SaveChanges();

            return RedirectToRoute("contribuintes");
        }

    }
}
