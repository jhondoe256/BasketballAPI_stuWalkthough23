using Basketball.Models.EntityModels.TeamModels;

namespace Basketball.Services.TeamServices
{
    public interface ITeamService
    {
        //    Task<bool> represents the 'return type'
        //    After all is said and done return true/false
        public Task<bool> AddTeam(TeamCreateVM model);
        public Task<bool> UpdateTeam(TeamUpdateVM model);
        public Task<bool> DeleteTeam(int id);
        public Task<TeamDetailVM> GetTeam(int id);
        public Task<List<TeamListItemVM>> GetTeams();
    }
}