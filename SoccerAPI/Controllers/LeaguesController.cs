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
using SoccerAPI.IRepository;
using SoccerAPI.Models;

namespace SoccerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaguesController : ControllerBase
    {
        
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LeaguesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/Leagues
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LeagueResource>>> GetLeagues()
        {
            var league = await _unitOfWork.Leagues.GetAll();
            var leagueResource = _mapper.Map<List<League>, List<LeagueResource>>((List<League>)league);
            return leagueResource;
        }

        // GET: api/Leagues/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeagueResource>> GetLeague(int id)
        {
            var league = await _unitOfWork.Leagues.GetT(l=>l.LeagueId==id);
            if (league == null){
                return NotFound();
            }
            var result = _mapper.Map<League,LeagueResource>(league);

            return Ok(result);
        }

        // PUT: api/Leagues/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLeague(int id, LeagueResource leagueResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var league = await _unitOfWork.Leagues.GetT(l => l.LeagueId == id);
            if (league == null)
                return NotFound();

            _mapper.Map<LeagueResource, League>(leagueResource, league);
            _unitOfWork.Leagues.Update(league);
           
           await _unitOfWork.Save();
            var result = _mapper.Map<League, LeagueResource>(league);
            return Ok(result);
        }

        // POST: api/Leagues
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostLeague([FromBody]LeagueResource leagueResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var league = _mapper.Map<LeagueResource, League>(leagueResource);

            await _unitOfWork.Leagues.Insert(league);
            await _unitOfWork.Save();
            var result = _mapper.Map<League, LeagueResource>(league);
           
            return Ok(result);
        }

        // DELETE: api/Leagues/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLeague(int id)
        {
            var league = await _unitOfWork.Leagues.GetT(l => l.LeagueId == id);
            if (league == null)
            {
                return NotFound("A league with this id was not found!");
            }

            await _unitOfWork.Leagues.Delete(id);
            await _unitOfWork.Save();

            return Ok(id);
        }

        
    }
}
