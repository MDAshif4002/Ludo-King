using System.ComponentModel.DataAnnotations;

namespace LudoKing.Models
{
    public class withdraw
    {
        [Key]
        public int id { get; set; }
        public string? bank { get; set; }
        public string? accountholder { get; set; }
        public string? ifsccode { get; set; }
        public string? accountnumber { get; set; }
        public string? amount { get; set; }
        public string? screenshot { get; set; }
        public string? datetime { get; set; }
    }
}
