using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AmericanGirlLookup.Models
{
    public class Doll
    {
        public int Id { get; set; }
        public required string DollName { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime RetirementDate { get; set; }
        public string? CharacterType { get; set; }
        public string? Collection { get; set; }
        [DataType(DataType.Currency)]
        public string? OriginalPrice { get; set; }
        [DataType(DataType.Currency)]
        public string? CurrentValue { get; set; }
        public required string OwningCompany { get; set; }
        public string? ImageUrl { get; set; }

        [NotMapped]
        public IFormFile? DollImage { get; set; }
    }
}
