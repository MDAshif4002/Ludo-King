using System.ComponentModel.DataAnnotations;

namespace LudoKing.Models
{
    public class slider
    {
        [Key]
        public int id {  get; set; }
        public string? pic { get; set; }
        public string? link { get; set; }
        public string? status { get; set; }
        public string? datetime { get; set; }
    }
}
