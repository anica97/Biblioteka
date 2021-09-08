using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using back.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace back.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BibliotekaController : ControllerBase
    {
        public BibliotekaContext Context { get; set; }
        public BibliotekaController(BibliotekaContext context)
        {
            Context = context;
        }

        [Route("PreuzmiBiblioteku")]
        [HttpGet]
        public async Task<List<Biblioteka>> PreuzmiBiblioteku()
        {
            return await Context.Biblioteke.Include(p => p.redovi).ThenInclude(r => r.knjige).ToListAsync();
        }
        [Route("UpisiBiblioteku")]
        [HttpPost]
          public async Task UpisiBiblioteku([FromBody] Biblioteka biblioteka)
        {
            Context.Biblioteke.Add(biblioteka); 
            await Context.SaveChangesAsync();
        }
        [Route("IzmeniBiblioteku")]
        [HttpPut]
        public async Task IzmeniBiblioteku([FromBody] Biblioteka biblioteka)
        {
            // var staraBib = await Context.Biblioteke.FindAsync(biblioteka.Id);
            // staraBib.redovi = biblioteka.redovi;
            // staraBib.Naziv = biblioteka.Naziv;
            Context.Update<Biblioteka>(biblioteka); 
            await Context.SaveChangesAsync();
        }
        [Route("DodajKnjigu")]
        [HttpPost]
          public async Task DodajKnjigu([FromBody] Knjiga knjiga)
        {
            Context.Knjige.Add(knjiga); 
            await Context.SaveChangesAsync();
        }
        [Route("ObrisiKnjigu/{id}")]
        [HttpDelete]
          public async Task ObrisiKnjigu(int id)
        {
            Knjiga knjiga = await Context.Knjige.FindAsync(id);
            Context.Remove(knjiga);
            await Context.SaveChangesAsync();
        }
    }
}
