using Basketball.Models.EntityModels.PositionModels;
using Basketball.Models.EntityModels.TeamModels;

namespace Basketball.Models.EntityModels.PlayerModels
{
    public class PlayerDetailsVM
    {
         
        public int Id { get; set; }
        
        public int JerseyNumber { get; set; }
        public string FirstName { get; set; } = string.Empty;
       
        public string LastName { get; set; } = string.Empty;
      
        public virtual PositionListItemVM? Position { get; set; }
       
        public virtual TeamListItemVM Team { get; set; } = null!;

    }
}