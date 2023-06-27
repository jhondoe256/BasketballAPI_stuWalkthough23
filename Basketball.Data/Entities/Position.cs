using System.ComponentModel.DataAnnotations;

namespace Basketball.Data.Entities
{
    public class Position
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(150)]
        public string Name { get; set; } = string.Empty;
    }
}