using System.ComponentModel.DataAnnotations;

namespace GameCatalogue.Models
{
    public class Developer
    {
        [Key]
        public int DeveloperId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Country { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Salary { get; set; }

        public ICollection<Game>? Games { get; set; }

    }
}
