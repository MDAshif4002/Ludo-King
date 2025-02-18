using System.ComponentModel.DataAnnotations;

namespace LudoKing.Models
{
    public class gamedetail
    {
        [Key]
        public int id { get; set; }
        public string? gameid { get; set; }
        public string? players { get; set; }
        public string? winmoney { get; set; }
        public string? winner { get; set; }
    }
}
