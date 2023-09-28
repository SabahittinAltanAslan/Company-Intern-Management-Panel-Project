using System.ComponentModel.DataAnnotations;

namespace stajerYonetim.Models
{
    public class Request
    {
        [Key]
        public int ReqId { get; set; }
        public string ReqName { get; set; }
        public string ReqtSurname { get; set; }
        public string ReqUni { get; set; }
        public string ReqDepart { get; set; }
        public string ReqClass { get; set; }
        public string ReqMail { get; set; }
        public string ReqNumber { get; set; }
        public string ReqGitHub { get; set; }
        public string ReqLengues { get; set; }
        public string ReqWant { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int CompId { get; set; }

        public Company Company { get; set; }

    }
}
