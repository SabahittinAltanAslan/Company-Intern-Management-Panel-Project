using System.ComponentModel.DataAnnotations;

namespace stajerYonetim.Models
{
    public class PdfRecord
    {
        [Key]
        public int Id { get; set; }
        public string FileName { get; set; }
        public string OriginalFileName { get; set; }
        public IList<Intern> Interns { get; set; } 
        
        public int InternId { get; set; }   
    }
}
