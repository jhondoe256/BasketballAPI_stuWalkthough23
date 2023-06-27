using Basketball.Models.EntityModels.PlayerModels;

namespace Basketball.Services.PlayerServices
{
    public interface IPlayerServiceNameTeam : IPlayerService
    {
        public Task<List<PlayerNameAndTeamVM>> GetPlayersAndTeam();
    }
}