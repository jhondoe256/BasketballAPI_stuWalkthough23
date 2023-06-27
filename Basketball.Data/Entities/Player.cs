using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Basketball.Data.Entities
{
    public class Player
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(150)]
        public string FirstName { get; set; } = string.Empty;
        [MaxLength(150)]
        public string LastName { get; set; } = string.Empty;

        public int? PositionId { get; set; }

        //navigation property
        // we use this w/n the services
        [ForeignKey(nameof(PositionId))]
        public virtual Position? Position { get; set; }

        public int TeamId { get; set; }

        [ForeignKey(nameof(TeamId))]
        public virtual Team Team { get; set; } = null!;

        public int JerseyNumber { get; set; }

    }
}