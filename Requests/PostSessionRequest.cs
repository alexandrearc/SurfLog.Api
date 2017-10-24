using System;
using System.ComponentModel.DataAnnotations;
using SurfLog.Api.Dtos;
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
        public Condition Condition { get; set; }
    }
}