namespace GameCatalogue.DTO
{
    public class DeveloperDto
    {
        public int DeveloperId { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public List<GameDto> Games { get; set; }
    }
}
