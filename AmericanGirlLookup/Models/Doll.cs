using System.ComponentModel.DataAnnotations;

namespace AmericanGirlLookup.Models
{
    public class Doll
    {
        public required int Id { get; set; }
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
        public required string ImagePath { get; set; }
    }
}
