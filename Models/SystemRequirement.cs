using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameCatalogue.Models
{
    public class SystemRequirement
    {
        [Key]
        public int RequirementsId { get; set; }

        [Required]
        public int GameId { get; set; }

        [ForeignKey(nameof(GameId))]
        public virtual Game Game { get; set; }

        public string MinimumCPU { get; set; }

        public string RecommendedCPU { get; set; }

        public string MinimumRAM { get; set; }

        public string RecommendedRAM { get; set; }

        public string RecommendedGraphics { get; set; }

        public string StorageRequired { get; set; }
    }
}
