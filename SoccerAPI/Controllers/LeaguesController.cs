using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoccerAPI.Controllers.Resources;
using SoccerAPI.Data;
using SoccerAPI.Models;

namespace SoccerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaguesController : ControllerBase
    {
        private readonly SoccerDbContext _context;
        private readonly IMapper _mapper;

        public LeaguesController(SoccerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Leagues
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LeagueResource>>> GetLeagues()
        {
            var league = await _context.Leagues.Include(l => l.Teams).ToListAsync();
            var leagueResource = _mapper.Map<List<League>, List<LeagueResource>>(league);
            return leagueResource;
        }

        // GET: api/Leagues/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeagueResource>> GetLeague(int id)
        {
            var league = await _context.Leagues.Include(l => l.Teams).SingleOrDefaultAsync(l => l.LeagueId == id);
            if (league == null)
                return NotFound();

            var leagueResource = _mapper.Map<League,LeagueResource>(league);

            return Ok(leagueResource);
        }

        // PUT: api/Leagues/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLeague(int id, League league)
        {
            if (id != league.LeagueId)
            {
                return BadRequest();
            }

            _context.Entry(league).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeagueExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Leagues
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostLeague([FromBody]LeagueResource leagueResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var league = _mapper.Map<LeagueResource, League>(leagueResource);
           
           
            _context.Leagues.Add(league);
            await _context.SaveChangesAsync();

            var result = _mapper.Map<League, LeagueResource>(league);

            return Ok(result);
        }

        // DELETE: api/Leagues/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLeague(int id)
        {
            var league = await _context.Leagues.FindAsync(id);
            if (league == null)
            {
                return NotFound();
            }

            _context.Leagues.Remove(league);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LeagueExists(int id)
        {
            return _context.Leagues.Any(e => e.LeagueId == id);
        }
    }
}
