using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProAgil.API.Data;
using ProAgil.API.Model;

namespace ProAgil.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly AppDataContext _context;
        
        public WeatherForecastController(AppDataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Evento>> GetEventos()
        {
            try
            {
                var result = await _context.Eventos.ToListAsync();
                
                return result;
            }
            catch (System.Exception)
            {       
                throw;
            }
        }

        // api/controller/id
        [HttpGet("{id}")]
        public async Task<Evento> Get(int id)
        {
            try
            {
                var result = await _context.Eventos.FirstOrDefaultAsync(x => x.EventoId == id);
                
                return result;
            }
            catch (System.Exception)
            {
                throw;
            }      
        }
    }
}
