using System.ComponentModel.DataAnnotations;
using SurfLog.Api.Enums;

namespace SurfLog.Api.Models
{
    public class Condition
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Session Session { get; set; }

        public string Tide { get; set; }
        
        [Required]
        public CardinalDirections Wind { get; set; }
        
        /// <summary>
        /// Wind Speed (kts).
        /// </summary>
        public int? Speed { get; set; }
        
        [Required]
        public CardinalDirections Swell { get; set; }
        
        /// <summary>
        /// Swell's angle (degrees).
        /// </summary>
        public int? Angle { get; set; }
        
        /// <summary>
        /// Swell's period (seconds).
        /// </summary>
        public int? Period { get; set; }
        
        /// <summary>
        /// Conditions' score from 1 to 5 stars.
        /// </summary>
        public int? Score { get; set; }

        public int SessionId { get; set; }
    }
}