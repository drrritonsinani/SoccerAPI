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
    public class TeamsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TeamsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/Teams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeamResource>>> GetTeams()
        {
            var team = await _unitOfWork.Teams.GetAll();
            var teamResource = _mapper.Map<List<Team>, List<TeamResource>>((List<Team>)team);
            return teamResource;
        }

        // GET: api/Teams/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TeamResource>> GetTeam(int id)
        {
            var team = await _unitOfWork.Teams.GetT(t => t.TeamId == id);
            if (team == null)
            {
                return NotFound();
            }
            var result = _mapper.Map<Team, TeamResource>(team);

            return Ok(result);
        }

        // PUT: api/Teams/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeam(int id, TeamResource teamResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var team = await _unitOfWork.Teams.GetT(t => t.TeamId == id);
            if (team == null)
                return NotFound();

            _mapper.Map<TeamResource, Team>(teamResource, team);
            _unitOfWork.Teams.Update(team);

            await _unitOfWork.Save();
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

            await _unitOfWork.Teams.Insert(team);
            await _unitOfWork.Save();
            var result = _mapper.Map<Team, TeamResource>(team);

            return Ok(result);
        }

        // DELETE: api/Teams/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            var team = await _unitOfWork.Teams.GetT(t => t.TeamId == id);
            if (team == null)
            {
                return NotFound("A team with this id was not found!");
            }

            await _unitOfWork.Teams.Delete(id);
            await _unitOfWork.Save();

            return Ok(id);
        }

        
    }
}
