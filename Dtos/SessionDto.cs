using System;
using SurfLog.Api.Models;

namespace SurfLog.Api.Dtos
{
    public class SessionDto
    {
        public int Id { get; set; }
        public int BeachId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public decimal Duration { get; set; }
        public int Rating { get; set; }
        public int UserId { get; set;}
    }
}