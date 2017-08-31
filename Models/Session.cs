using System;
using System.ComponentModel.DataAnnotations;

namespace SurfLog.Api.Models
{
    public class Session
    {
        [Key]
        public int Id { get; set; }
        public Beach Beach { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public decimal Duration { get; set; }
        public int Rating { get; set; }
    }
}