using System;
using System.ComponentModel.DataAnnotations;
using SurfLog.Api.Models;

namespace SurfLog.Api.Requests
{
    public class PostSessionRequest
    {
        [Required]
        public int BeachId { get; set; }
        
        [Required]
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public decimal Duration { get; set; }
        public int Rating { get; set; }
        public string UserId { get; set;}
        public string Swell { get; set; }
        public int Angle { get; set; }  
        public int Period { get; set; } 
        public string Wind { get; set; }
        public int Speed { get; set; }
        public int Score { get; set; }
    }
}