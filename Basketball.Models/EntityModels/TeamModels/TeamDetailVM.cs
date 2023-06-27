using Basketball.Models.EntityModels.PlayerModels;

namespace Basketball.Models.EntityModels.TeamModels
{
    public class TeamDetailVM
    {
           
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        
        //VM ONLY TALK TO VM (Also known as DTOs)
         public List<PlayerListItemVM>? Players { get; set; }
    }
}