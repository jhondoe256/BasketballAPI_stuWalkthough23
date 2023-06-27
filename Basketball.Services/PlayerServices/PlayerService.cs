using AutoMapper;
using Basketball.Data.Context;
using Basketball.Data.Entities;
using Basketball.Models.EntityModels.PlayerModels;
using Microsoft.EntityFrameworkCore;

namespace Basketball.Services.PlayerServices
{
    public class PlayerService : IPlayerServiceNameTeam
    {
        private readonly BasketBallDbContext _context;
        private readonly IMapper _mapper;

        public PlayerService(BasketBallDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> AddPlayer(PlayerCreateVM model)
        {
            var entity = _mapper.Map<Player>(model);

            if (entity is not null)
            {
                await _context.Players.AddAsync(entity);
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<bool> DeletePlayer(int id)
        {
            var perInDb = await _context.Players.FindAsync(id);
            if (perInDb is null) return false;
            else
            {
                _context.Players.Remove(perInDb);
                await _context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<PlayerDetailsVM> GetPlayer(int id)
        {
            var perInDb = await _context.Players.Include(p=>p.Team).Include(p=>p.Position).SingleOrDefaultAsync(x=>x.Id == id);
            if (perInDb is null) return null!;

            return _mapper.Map<PlayerDetailsVM>(perInDb);
        }

        public async Task<List<PlayerListItemVM>> GetPlayers()
        {
            return await _context.Players.Select(p => _mapper.Map<PlayerListItemVM>(p)).ToListAsync();
        }

        public async Task<List<PlayerNameAndTeamVM>> GetPlayersAndTeam()
        {
           return await _context.Players.Include(p=>p.Team).Select(p=> new PlayerNameAndTeamVM{
             FirstName= p.FirstName,
             LastName= p.LastName,
             TeamName = p.Team.Name,

           }).ToListAsync();
        }

        public async Task<bool> UpdatePlayer(PlayerUpdateVM model)
        {
            var perInDb = await _context.Players.AsNoTracking().SingleOrDefaultAsync(x => x.Id == model.Id);
            if (perInDb is null) return false;

            var conversion = _mapper.Map<PlayerUpdateVM, Player>(model);

            if (conversion is not null)
            {
                _context.Players.Update(conversion);

                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}