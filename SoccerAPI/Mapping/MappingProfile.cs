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
            CreateMap<League, LeagueResource>()
                .ForMember(lr => lr.Teams, opt => opt.MapFrom(l => l.Teams.Select(t => t.Name)));

            CreateMap<Team, TeamResource>();
            CreateMap<Player, PlayerResource>()
                .ForMember(pr=>pr.Positions,opt=>opt.MapFrom(p=>p.Positions.Select(ps=>ps.PositionId)));
            CreateMap<Manager, ManagerResource>();

            // API Resource to Domain
            CreateMap<LeagueResourceId,League>()
                .ForMember(league => league.LeagueId, opt => opt.Ignore())
              .ForMember(league => league.Teams, opt => opt.Ignore())
                .AfterMap((leagueResourceId, league) =>
                {
                    // Remove unselected positions
                    var removedTeams = league.Teams.Where(id => !leagueResourceId.Teams.Contains(league.LeagueId));
                    foreach (var team in removedTeams)
                        league.Teams.Remove(team);

                    // Add new positions
                    var addedTeams = leagueResource.Teams.Where(name => !league.Teams.Any(teams => teams.Name == name)).Select(name => new League { Name = name });
                    foreach (var team in addedTeams)
                        league.Teams.Add(team);
                });
            CreateMap<LeagueResource, League>();                                 
                
              
            CreateMap<TeamResource, Team>();
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
            CreateMap<ManagerResource, Manager>();
        }
    }
}
