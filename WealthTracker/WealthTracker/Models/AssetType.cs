using System.ComponentModel.DataAnnotations;

namespace WealthTracker.Models
{
    public class AssetType
    {
        [Key]
        public int AssetTypeId { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; } 
    }
}
