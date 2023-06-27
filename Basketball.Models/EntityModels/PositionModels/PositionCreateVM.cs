using System.ComponentModel.DataAnnotations;

namespace Basketball.Models.EntityModels.PositionModels
{
    public class PositionCreateVM
    {
      
        [Required]
        [MaxLength(150)]
        public string Name { get; set; } = string.Empty;
    }
}