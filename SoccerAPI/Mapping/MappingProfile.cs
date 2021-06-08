using AutoMapper;
using SoccerAPI.Controllers.Resources;
using SoccerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerAPI.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            // Domain to API Resource
            CreateMap<League, LeagueResource>();
               

            CreateMap<Team, TeamResource>();
            CreateMap<Team, TeamResource2>();
            CreateMap<Player, PlayerResource>()
                .ForMember(pr=>pr.Positions,opt=>opt.MapFrom(p=>p.Positions.Select(ps=>ps.PositionId)));
            CreateMap<Player, PlayerResource2>();
            CreateMap<Manager, ManagerResource>();

            // API Resource to Domain
           
            CreateMap<LeagueResource, League>();                                 
               
            CreateMap<TeamResource, Team>();
            CreateMap<TeamResource2,Team>();
            CreateMap<PlayerResource, Player>()
              .ForMember(player => player.Id, opt => opt.Ignore())
              .ForMember(player => player.Positions, opt => opt.Ignore())
              .AfterMap((playerResource, player) =>
              {
                  // Remove unselected positions
                  var removedPositions = player.Positions.Where(positions => !playerResource.Positions.Contains(positions.PositionId));
                  foreach (var position in removedPositions)
                      player.Positions.Remove(position);

                  // Add new positions
                  var addedPositions = playerResource.Positions.Where(id => !player.Positions.Any(postions => postions.PositionId == id)).Select(id => new PlayerPosition { PositionId = id });
                  foreach (var position in addedPositions)
                      player.Positions.Add(position);
              });
            CreateMap<PlayerResource2, Player>();
            CreateMap<ManagerResource, Manager>();
        }
    }
}
