using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameCatalogue.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }

        [ForeignKey("Game")]
        public int GameId { get; set; }
        public virtual Game Game { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; } 
        public virtual User User { get; set; }

        public decimal Rating { get; set; }
        public DateTime ReviewDate { get; set; }

        [Required]
        [StringLength(5000)]
        public string ReviewText { get; set; }

        public Review()
        {

        }
    }
}
