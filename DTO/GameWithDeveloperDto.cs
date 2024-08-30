namespace GameCatalogue.DTO
{
    public class GameWithDeveloperDto
    {
        public int GameId { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string DeveloperName { get; set; }
        public string DeveloperEmail { get; set; }
    }
}
