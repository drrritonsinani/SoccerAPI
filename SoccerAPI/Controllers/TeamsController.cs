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
    public class TeamsController : ControllerBase
    {
        private readonly SoccerDbContext _context;
        private readonly IMapper _mapper;

        public TeamsController(SoccerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Teams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeamResource>>> GetTeams()
        {
            var team = await _context.Teams.Include(t => t.Players).ToListAsync();
            var teamResource = _mapper.Map<List<Team>, List<TeamResource>>(team);
            return teamResource;
        }

        // GET: api/Teams/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TeamResource>> GetTeam(int id)
        {
            var team = await _context.Teams.Include(t => t.Players).SingleOrDefaultAsync(l => l.TeamId == id);
            if (team == null)
                return NotFound();

            var teamResource = _mapper.Map<Team, TeamResource>(team);

            return Ok(teamResource);
        }

        // PUT: api/Teams/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeam(int id, TeamResource teamResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var team = await _context.Teams.SingleOrDefaultAsync(t => t.TeamId == id);
            if (team == null)
                return NotFound();

            _mapper.Map<TeamResource, Team>(teamResource, team);

            await _context.SaveChangesAsync();
            var result = _mapper.Map<Team, TeamResource>(team);

            return Ok(result);
        }

        // POST: api/Teams
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Team>> PostTeam(TeamResource teamResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var team = _mapper.Map<TeamResource, Team>(teamResource);


            _context.Teams.Add(team);
            await _context.SaveChangesAsync();



            return Ok("Team has been created!");
        }

        // DELETE: api/Teams/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            var team = await _context.Teams.Include(t => t.Players).SingleOrDefaultAsync(t => t.TeamId == id);
            if (team == null)
            {
                return NotFound();
            }



            _context.Teams.Remove(team);
            foreach (var player in team.Players)
            {
                player.Team = null;
            }
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TeamExists(int id)
        {
            return _context.Teams.Any(e => e.TeamId == id);
        }
    }
}
