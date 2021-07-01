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
    public class PlayerController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PlayerController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/Player
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayerResource>>> GetPlayers()
        {
            var player = await _unitOfWork.Players.GetAll();
            var result = _mapper.Map<List<Player>, List<PlayerResource>>((List<Player>)player);
            return result;
        }

        // GET: api/Player/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Player>> GetPlayer(int id)
        {
            var player = await _unitOfWork.Players.GetT(p => p.Id == id);
            if (player == null)
            {
                return NotFound();
            }
            var result = _mapper.Map<Player, PlayerResource>(player);

            return Ok(result);
        }

        // PUT: api/Player/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayer(int id,[FromBody] PlayerResource playerResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var player = await _unitOfWork.Players.GetT(p => p.Id == id);
            if (player == null)
                return NotFound();

            _mapper.Map<PlayerResource, Player>(playerResource, player);
            _unitOfWork.Players.Update(player);

            await _unitOfWork.Save();
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

            await _unitOfWork.Players.Insert(player);
            await _unitOfWork.Save();
            var result = _mapper.Map<Player, PlayerResource>(player);

            return Ok(result);
        }

        // DELETE: api/Player/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayer(int id)
        {

            var player = await _unitOfWork.Players.GetT(p => p.Id == id);
            if (player == null)
            {
                return NotFound("A player with this id was not found!");
            }

            await _unitOfWork.Players.Delete(id);
            await _unitOfWork.Save();

            return Ok(id);
        }

       
    }
}
