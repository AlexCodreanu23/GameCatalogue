using System.ComponentModel.DataAnnotations;

namespace GameCatalogue.Models
{
    public class GameDeveloper
    {
        [Key]
        public int GameDeveloperId { get; set; }

        public int GameId { get; set; }
        public Game Game { get; set; }

        public int DeveloperId { get; set; }
        public Developer Developer { get; set; }
    }
}