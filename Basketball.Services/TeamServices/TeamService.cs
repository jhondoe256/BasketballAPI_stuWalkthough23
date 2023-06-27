using AutoMapper;
using Basketball.Data.Context;
using Basketball.Data.Entities;
using Basketball.Models.EntityModels.TeamModels;
using Microsoft.EntityFrameworkCore;

namespace Basketball.Services.TeamServices
{
    public class TeamService : ITeamService
    {
        private readonly BasketBallDbContext _context;
        private readonly IMapper _mapper;

        public TeamService(BasketBallDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> AddTeam(TeamCreateVM model)
        {
            var entity = _mapper.Map<Team>(model);

            await _context.Teams.AddAsync(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteTeam(int id)
        {
            var teamInDb = await _context.Teams.FirstOrDefaultAsync(team => team.Id == id);
            if (teamInDb is null) return false;
            else
            {
                _context.Teams.Remove(teamInDb);
                await _context.SaveChangesAsync();
                return true;
            }

        }

        public async Task<TeamDetailVM> GetTeam(int id)
        {
            var teamInDb = await _context.Teams.Include(t=>t.Players).SingleOrDefaultAsync(team => team.Id == id);
            if (teamInDb is null) return null!;

            return _mapper.Map<TeamDetailVM>(teamInDb);
        }

        public async Task<List<TeamListItemVM>> GetTeams()
        {
            var team = await _context.Teams.ToListAsync();

            return _mapper.Map<List<TeamListItemVM>>(team);
        }

        public async Task<bool> UpdateTeam(TeamUpdateVM model)
        {
            var teamInDb = await _context.Teams.FirstOrDefaultAsync(team => team.Id == model.Id);
            if (teamInDb is null) return false;

            teamInDb.Name = model.Name;
            return await _context.SaveChangesAsync() > 0;
        }
    }
}