using System.ComponentModel.DataAnnotations;

namespace stajerYonetim.Models
{
    public class Intern
    {
        [Key]
        public int InternId { get; set; }
        public string InternName { get; set; }
        public string InterntSurname { get; set; }
        public string InternUni { get; set; }
        public string InternDepart { get; set; }
        public string InternClass { get; set; }
        public string InternMail { get; set; }
        public string InternNumber { get; set; }
        public string InternGitHub { get; set; }
        public string InternLengues { get; set; }
        public string InternWant { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int CompId { get; set; }

        public Company Company { get; set; }

        public IList<PdfRecord> PdfRecords { get; set; }
        public IList<Document> Documents { get; set; }
        

        public int Id { get; set; }

    }
}
