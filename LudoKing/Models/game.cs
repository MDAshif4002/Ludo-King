using System.ComponentModel.DataAnnotations;

namespace LudoKing.Models
{
    public class game
    {
        [Key]
        public int id { get; set; }
        public string? gametype { get; set; }
        public string? amount { get; set; }
        public string? player1 { get; set; }
        public string? player2 { get; set; }
        public string? roomcode { get; set; }
        public string? userresult { get; set; }
        public string? resultscreenshot { get; set; }
        public string? finalresult { get; set; }
        public string? datetime { get; set; }
    }
}
