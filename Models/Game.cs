﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GameCatalogue.Models
{
    public class Game
    {
        [Key]
        public int GameId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        public string Genre { get; set; }

        public decimal Price { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }
        public SystemRequirement? SystemRequirement { get; set; }

        public ICollection<Review>? Reviews { get; set; } = new List<Review>();

        public ICollection<GameDeveloper>? GameDevelopers { get; set; } = new List<GameDeveloper>();
    }
}
