using System.ComponentModel.DataAnnotations;

namespace Basketball.Models.EntityModels.TeamModels
{
    public class TeamUpdateVM
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Name { get; set; } = string.Empty;

    }
}