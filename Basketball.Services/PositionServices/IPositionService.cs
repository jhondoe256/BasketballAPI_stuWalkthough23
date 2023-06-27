using Basketball.Models.EntityModels.PositionModels;

namespace Basketball.Services.PositionServices
{
    public interface IPositionService
    {
        //add the position and then when all is done return some info back to the user
        // if successful
        public Task<PositionListItemVM> AddPosition(PositionCreateVM model);
        public Task<bool> UpdatePosition(PositionUpdateVM model);
        public Task<bool> DeletePosition(int id);
        public Task<PositionListItemVM> GetPosition(int id);
        public Task<List<PositionListItemVM>> GetPositions();
    }
}