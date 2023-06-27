using System.ComponentModel.DataAnnotations;

namespace Basketball.Models.EntityModels.PlayerModels
{
    public class PlayerCreateVM
    {

        [Required]
        [MaxLength(150)]
        public string FirstName { get; set; } = string.Empty;
        
        [Required]
        [MaxLength(150)]
        public string LastName { get; set; } = string.Empty;

        public int? PositionId { get; set; }

        [Required]
        public int TeamId { get; set; }

        [Required]
        public int JerseyNumber { get; set; }
    }
}