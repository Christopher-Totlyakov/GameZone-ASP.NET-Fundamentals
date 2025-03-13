using GameZone.Data.DataModels;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Security.Policy;
using static GameZone.ComanConsts;

namespace GameZone.Models
{
    public class GameViewModel
    {
        [Required]
        [MaxLength(TitleMaxLength)]
        [MinLength(TitleMinLength)]
        public string Title { get; set; } = string.Empty;


        public string? ImageUrl { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        [MinLength(DescriptionMinLength)]
        public  string Description { get; set; } = string.Empty;

        [Required]
        public string ReleasedOn { get; set; } = DateTime.Today.ToString(GameReleasedOnDataFormat);

        [Required]
        public  int GenreId { get; set; }


        public List<Genre> Genres { get; set; } = new List<Genre>();



    }
}
