using System.ComponentModel.DataAnnotations;

namespace Basketball.Models.EntityModels.TeamModels
{
    public class TeamCreateVM
    {
        [Required]
        [MaxLength(150)]
        public string Name { get; set; } = string.Empty;

    }
}