using System.ComponentModel.DataAnnotations;

namespace stajerYonetim.Models
{
    public class Document
    {
        [Key]
        public int Id { get; set; }
        public string FileName { get; set; }
        public string OriginalFileName { get; set; }
        public Intern Intern { get; set; }
        public int InternId { get; set; }
    }
}
