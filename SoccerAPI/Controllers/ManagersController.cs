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
    public class ManagersController : ControllerBase
    {
        private readonly SoccerDbContext _context;
        private readonly IMapper _mapper;

        public ManagersController(SoccerDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Managers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ManagerResource>>> GetManagers()
        {
            var managers = await _context.Managers.ToListAsync();
            var result = _mapper.Map<List<Manager>, List<ManagerResource>>(managers);
            return result;
        }

        // GET: api/Managers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ManagerResource>> GetManager(int id)
        {
            var manager = await _context.Managers.FindAsync(id);

            if (manager == null)
            {
                return NotFound();
            }
            var result = _mapper.Map<Manager, ManagerResource>(manager);
            return result;
        }

        // PUT: api/Managers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutManager(int id, ManagerResource managerResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var manager = await _context.Managers.SingleOrDefaultAsync(m => m.ManagerId == id);
            if (manager == null)
                return NotFound();

            _mapper.Map<ManagerResource, Manager>(managerResource, manager);

            await _context.SaveChangesAsync();
            var result = _mapper.Map<Manager, ManagerResource>(manager);

            return Ok(result);
        }

        // POST: api/Managers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Manager>> PostManager(ManagerResource managerResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var manager = _mapper.Map<ManagerResource, Manager>(managerResource);


            _context.Managers.Add(manager);
            await _context.SaveChangesAsync();



            return Ok("manager has been created!");
        }

        // DELETE: api/Managers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteManager(int id)
        {
            var manager = await _context.Managers.Include(m=>m.Team).SingleOrDefaultAsync(m => m.ManagerId == id);
            if (manager == null)
            {
                return NotFound();
            }
            _context.Managers.Remove(manager);
           
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ManagerExists(int id)
        {
            return _context.Managers.Any(e => e.ManagerId == id);
        }
    }
}
