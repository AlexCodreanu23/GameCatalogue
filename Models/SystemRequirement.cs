using System.ComponentModel.DataAnnotations;

namespace GameCatalogue.Models
{
    public class SystemRequirement
    {
        [Key]
        public int RequirementsId { get; set; }

        public int? GameId { get; set; }

        public string? MinimumCPU { get; set; }

        public string? RecommendedCPU { get; set; }

        public string? MinimumRAM { get; set; }

        public string? RecommendedRAM { get; set; }

        public string? RecommendedGraphics { get; set; }

        public string? StorageRequired { get; set; }

        public Game? Game { get; set; }
    }
}
