using System.ComponentModel.DataAnnotations;

namespace SurfLog.Api.Models {

    public class Beach {
        
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public string Type { get; set; }
        
        public string Swell { get; set; }
        
        public string Wind { get; set; }
        
        public string Skill { get; set; }

        public string Ground { get; set; }

        public Beach(){

        }
    }
}