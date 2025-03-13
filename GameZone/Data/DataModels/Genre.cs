using System.ComponentModel.DataAnnotations;
using static GameZone.ComanConsts;

namespace GameZone.Data.DataModels
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GanreNameMaxLength)]
        public string Name { get; set; } = null!;

        public ICollection<Game> Games { get; set; } = new List<Game>();
    }
}