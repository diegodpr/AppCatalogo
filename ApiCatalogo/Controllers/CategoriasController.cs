using ApiCatalogo.Context;
using ApiCatalogo.Models;
using Microsoft.AspNetCore.Http;
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
    public class CategoriasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoriasController (AppDbContext context)
        {
            _context = context;
        }

        [HttpGet(Name ="GetCategorias")]
        public ActionResult<IEnumerable<Categoria>> Get()
        {
            return _context.Categorias.AsNoTracking().ToList();
        }

        [HttpGet("produtos")]
        public ActionResult<IEnumerable<Categoria>> GetCategoriaProdutos()
        {
            try
            {
                return _context.Categorias.Include(x => x.Produtos).ToList();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao se conectar com banco de dados");
            }

            
        }

        [HttpGet("{id}", Name = "ObterCategoria")]
        public ActionResult<Categoria> Get(int id)
        {
            var categoria = _context.Categorias.AsNoTracking().FirstOrDefault(c => c.CategoriaId == id);
            if(categoria == null)
            {
                return NotFound();
            }

            return categoria;

        }


        [HttpPost]
        public ActionResult Post([FromBody]Categoria categoria)
        {
            if(categoria == null)
            {
                return BadRequest();
            }

            _context.Add(categoria);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterCategoria", new {id = categoria.CategoriaId }, categoria);
        }

        [HttpPut("{id}")]
        
        public ActionResult Put(int id, [FromBody]Categoria categoria)
        {
            _context.Entry(categoria).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok();
        }


        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var categoria = _context.Categorias.AsNoTracking().FirstOrDefault(c => c.CategoriaId == id);

            _context.Categorias.Remove(categoria);
            _context.SaveChanges();

            return RedirectToRoute("GetCategorias");
        }
    }
}
