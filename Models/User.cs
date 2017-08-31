using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SurfLog.Api.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public IEnumerable<Session> Session { get; set; }
    }
}