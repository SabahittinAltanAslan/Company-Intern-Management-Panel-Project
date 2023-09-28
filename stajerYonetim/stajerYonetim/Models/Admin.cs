using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace stajerYonetim.Models
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }
        public string AdminName { get; set; }
        public string AdminSurname { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }


        public int CompId { get; set; }
        public Company Company { get; set; }

    }
}
