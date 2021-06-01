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
    public class PlayerController : ControllerBase
    {
        private readonly SoccerDbContext _context;
        private readonly IMapper _mapper;

        public PlayerController(SoccerDbContext context, IMapper mapper)
        {
            _context = context;
           _mapper = mapper;
        }

        // GET: api/Player
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayerResource>>> GetPlayers()
        {
            var players = await _context.Players.Include(p => p.Positions).ToListAsync();
            var playerResource = _mapper.Map<List<Player>, List<PlayerResource>>(players);
            return playerResource;
        }

        // GET: api/Player/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Player>> GetPlayer(int id)
        {
            var player = await _context.Players.Include(p=>p.Positions).SingleOrDefaultAsync(p=>p.Id==id);

            if (player == null)
            {
                return NotFound();
            }
            var playerResource = _mapper.Map<Player, PlayerResource>(player);
            return Ok(playerResource);
        }

        // PUT: api/Player/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayer(int id,[FromBody] PlayerResource playerResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var player=await _context.Players.Include(p => p.Positions).SingleOrDefaultAsync(p => p.Id == id);
            _context.Entry(player).State = EntityState.Modified;

            if (player == null)
                return NotFound();
            _mapper.Map<PlayerResource, Player>(playerResource, player);
            await _context.SaveChangesAsync();
            var result = _mapper.Map<Player, PlayerResource>(player);

            return Ok(result);
        }

        // POST: api/Player
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostPlayer([FromBody] PlayerResource playerResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var player = _mapper.Map<PlayerResource, Player>(playerResource);
            _context.Players.Add(player);
            await _context.SaveChangesAsync();

            var result = _mapper.Map<Player, PlayerResource>(player);

            return Ok(result);
        }

        // DELETE: api/Player/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayer(int id)
        {

            var player = await _context.Players.FindAsync(id);

            if (player == null)
                return NotFound();

            _context.Remove(player);

            await _context.SaveChangesAsync();
            return Ok(id);
        }

       
    }
}
