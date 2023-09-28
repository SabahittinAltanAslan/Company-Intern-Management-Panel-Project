using System.ComponentModel.DataAnnotations;
using stajerYonetim.Models;

namespace stajerYonetim.Models
{
    public class Company
    {
        [Key]
        public int CompId { get; set; }
        public string CompName { get; set; }
        public IList<Admin> Admins { get; set; }
        public IList<Intern> Interns { get; set; }
        public IList<Request> Requests { get; set; }

    }
}
