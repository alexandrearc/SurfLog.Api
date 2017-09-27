using System.ComponentModel.DataAnnotations;
using SurfLog.Api.Enums;

namespace SurfLog.Api.Models
{
    public class Condition
    {
        [Key]
        public int Id { get; set; }
        public Session Session { get; set; }
        public string Tide { get; set; }
        public CardinalDirections Wind { get; set; }
        public int Speed { get; set; }
        public CardinalDirections Swell { get; set; }
        public int Angle { get; set; }
        public int Period { get; set; }
        public int Score { get; set; }
    }
}