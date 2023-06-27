using Basketball.Models.EntityModels.PlayerModels;

namespace Basketball.Services.PlayerServices
{
    public interface IPlayerService
    {
        public Task<bool> AddPlayer(PlayerCreateVM model);
        public Task<bool> UpdatePlayer(PlayerUpdateVM model);
        public Task<bool> DeletePlayer(int id);
        public Task<PlayerDetailsVM> GetPlayer(int id);
        public Task<List<PlayerListItemVM>> GetPlayers();
    }
}