using System.ComponentModel.DataAnnotations;

namespace LudoKing.Models
{
    public class adminlogin
    {
        [Key]
        public int id { get; set; }
        public string? name { get; set; }
        public string? email { get; set; }
        public string? mobile { get; set; }
        public string? password { get; set; }
    }
}
