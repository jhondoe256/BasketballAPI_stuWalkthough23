using AutoMapper;
using Basketball.Data.Context;
using Basketball.Data.Entities;
using Basketball.Models.EntityModels.PositionModels;
using Microsoft.EntityFrameworkCore;

namespace Basketball.Services.PositionServices
{
    public class PositionService : IPositionService
    {
        private readonly BasketBallDbContext _context;
        private readonly IMapper _mapper;

        public PositionService(BasketBallDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PositionListItemVM> AddPosition(PositionCreateVM model)
        {
            var entity = _mapper.Map<Position>(model);
            if (entity is not null)
            {
                await _context.Positions.AddAsync(entity);
                int numberOfChanges = await _context.SaveChangesAsync();

                if (numberOfChanges == 1)
                {
                    return _mapper.Map<PositionListItemVM>(entity);
                }
            }
            return null!;

        }

        public async Task<bool> DeletePosition(int id)
        {
            var posInDb = await _context.Positions.FindAsync(id);
            if (posInDb is null) return false;
            else
            {
                _context.Positions.Remove(posInDb);
                await _context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<PositionListItemVM> GetPosition(int id)
        {
            var posInDb = await _context.Positions.FindAsync(id);
            if (posInDb is null) return null!;

            return _mapper.Map<PositionListItemVM>(posInDb);
        }

        public async Task<List<PositionListItemVM>> GetPositions()
        {
            var positions = await _context.Positions.ToListAsync();
            return _mapper.Map<List<PositionListItemVM>>(positions);
        }

        public async Task<bool> UpdatePosition(PositionUpdateVM model)
        {
            var posInDb = await _context.Positions.SingleOrDefaultAsync(x => x.Id == model.Id);
            if (posInDb is null) return false;

            posInDb.Name = model.Name;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}