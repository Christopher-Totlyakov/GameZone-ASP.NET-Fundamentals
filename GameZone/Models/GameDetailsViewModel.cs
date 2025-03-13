using GameZone.Data.DataModels;
using Microsoft.AspNetCore.Identity;

namespace GameZone.Models
{
    public class GameDetailsViewModel
    {
        public string? ImageUrl { get; set; }

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public Genre Genre { get; set; } = null!;

        public DateTime ReleasedOn { get; set; }

        public string Publisher { get; set; } = null!;

        public int Id { get; set; }
    }
}
