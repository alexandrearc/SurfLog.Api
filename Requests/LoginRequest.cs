using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SurfLog.Api.Requests
{
    public class LoginRequest
    {
        [Required]
        public string UserName { get; set; }
        
        [Required]
        public string Password { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext){
            return null;
        }
    }
}