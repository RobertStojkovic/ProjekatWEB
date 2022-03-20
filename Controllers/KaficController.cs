using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Kafic_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KaficController : ControllerBase
    {
         public KaficContext Context {get; set;}

        public KaficController(KaficContext context)
        {
            Context=context;
        }

        [Route("PreuzmiKafici")]
        [HttpGet]
        public async Task<List<Kafic>> PreuzmiKafici()
        {
            
            return await Context.Kafici.Include(p=>p.Stolovi).Include(p=>p.Porudzbine).ToListAsync();
        }

        [Route("UpisiKafic")]
        [HttpPost]
        public async Task UpisiKafic([FromBody] Kafic kafic)
        {
          if(kafic != null)
          {    
               Context.Kafici.Add(kafic);
               await Context.SaveChangesAsync();
          }
          else{
              BadRequest("Niste uneli nista.");
          }
          

        }

        [Route("IzmeniKafic")]
        [HttpPut]
        public async Task IzmeniKafic([FromBody] Kafic kafic)
        {
            if(kafic != null)
            {    
                 Context.Kafici.Update(kafic);
                await Context.SaveChangesAsync();
            }
          else{
              BadRequest("Niste uneli nista.");
           }

        }

        [Route("IzbrisiKafic/{id}")]
        [HttpDelete]
        public async Task IzbrisiKafic(int id)
        {
            var kaf= await Context.Kafici.FindAsync(id);
            if(kaf!=null)
            {
                Context.Kafici.Remove(kaf);
                await Context.SaveChangesAsync();
            }
            else{
                 BadRequest ("Ne postoji Kafic sa tim ID-em.");
            }
            
        }

        [Route("ZauzmiSto/{id}")]
        [HttpPost]
        public async Task<IActionResult>  ZauzmiSto(int id, [FromBody] Sto sto)
        {
            var kaf= await Context.Kafici.FindAsync(id);
            if(kaf != null)
            {
                sto.Kafic=kaf;
            }
            else{
                BadRequest ("Ne postoji sto sa tim ID-em.");
            }
            
            var sto_pret= await Context.Stolovi.Where(s=> s.BrojStola==sto.BrojStola && s.Kafic.ID==id).FirstOrDefaultAsync();
            if(sto_pret!=null)
            {
                return BadRequest("Sto sa tim ID-em vec postoji.");

            }
            else{
                Context.Stolovi.Add(sto);
                await Context.SaveChangesAsync();
                return Ok();
            }
            
           

        }

        [Route("OslobodiSto/{br}/{id}")]
        [HttpDelete]
        public async Task OslobodiSto(int br, int id)
        {
            var sto= await Context.Stolovi.Where(s=> s.BrojStola==br && s.Kafic.ID==id).FirstOrDefaultAsync();
            if(sto != null)
            {
                Context.Stolovi.Remove(sto);
                await Context.SaveChangesAsync();
            }
            else{
                 BadRequest("Sto sa tim ID-em ne postoji.");
            }
  
        }


        [Route("IzmeniSto/{br}/{ime}/{prezime}/{brljudi}")]
        [HttpPut]
        public async Task IzmeniSto(int br, string ime, string prezime, int brljudi)
        {
            var sto= await Context.Stolovi.Where(s=> s.BrojStola==br).FirstOrDefaultAsync();
            if(sto!=null){
                sto.Ime=ime;
                sto.Prezime=prezime;
                sto.KapacitetStola=brljudi;
                await Context.SaveChangesAsync();
            }
            else{
             BadRequest("Sto sa tim ID-em ne postoji.");
            }
        }

        [Route("DodajPorudzbinu/{id}")]
        [HttpPost]
        public async Task DodajPorudzbinu(int id, [FromBody] Porudzbina pr)
        {
            var kaf=await Context.Kafici.FindAsync(id);
            if(kaf!=null)
            {
                pr.Kafic=kaf;
                Context.Porudzbine.Add(pr);
                await Context.SaveChangesAsync();
            }
            else{
                BadRequest ("Ne postoji Kafic sa tim ID-em.");
            }
            
        }

        [Route("OtkaziPorudzbinu/{br}")]
        [HttpDelete]
        public async Task OtkaziPorudzbinu(int br)
        {
          var pr= await Context.Porudzbine.Where(p=>p.IDPorudzbine==br).FirstOrDefaultAsync();
          Context.Porudzbine.Remove(pr);
          await Context.SaveChangesAsync();
        }

        [Route("IzmeniPorudzbinu/{br}/{deserti}/{pice}")]
        [HttpPut]
        public async Task IzmeniPorudzbinu(int br, string deserti, string pice)
        {
          var pr= await Context.Porudzbine.Where(p=>p.IDPorudzbine==br).FirstOrDefaultAsync();
          pr.Deserti=deserti;
          pr.Pice=pice;
          await Context.SaveChangesAsync();
        }

        [Route("PreuzmiStolove/{idStola}")]
        [HttpGet]
        public async Task<List<Sto>> PreuzmiStolove(int id)
        {
            return await Context.Stolovi.Where(sto=>sto.Kafic.ID==id).ToListAsync();
        }

        [Route("PreuzmiStolove1")]
        [HttpGet]
        public async Task<List<Sto>> PreuzmiStolove1()
        {
            return await Context.Stolovi.ToListAsync();
        }

      
    }
}
