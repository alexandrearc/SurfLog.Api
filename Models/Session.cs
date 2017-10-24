using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace SurfLog.Api.Models
{
    [JsonObject(IsReference = true)]
    public class Session
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public int BeachId { get; set; }
        
        [Required]
        public DateTime Date { get; set; }
        
        public string Description { get; set; }

        public decimal Duration { get; set; }

        public int Rating { get; set; }

        [Required]
        public string UserId { get; set;}

        public virtual Condition Condition { get; set; }
    }
}