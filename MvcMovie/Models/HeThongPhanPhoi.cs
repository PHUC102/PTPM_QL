using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcMovie.Models
{
   
    public class HeThongPhanPhoi
    {
        [Key]
    
        public string? MaHTTP {get; set;}
        public string? TenHTTP {get; set;}
        
    }
}