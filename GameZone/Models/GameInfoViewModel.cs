namespace GameZone.Models
{
    public class GameInfoViewModel
    {
        public string? ImageUrl { get; set; }

        public required string Title { get; set; }

        public required string Genre { get; set; }

        public required string ReleasedOn { get; set; }

        public int Id { get; set; }

        public required string Publisher { get; set; }
    }
}
