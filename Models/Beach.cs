using System.ComponentModel.DataAnnotations;

namespace SurfLog.Api.Models {

    public class Beach {
        
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}