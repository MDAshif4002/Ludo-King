using System.ComponentModel.DataAnnotations;

namespace LudoKing.Models
{
    public class panaltyincome
    {
        [Key]
        public int id {  get; set; }
        public string? name { get; set; }
        public string? type { get; set; }
        public string? amount { get; set; }
        public string? date { get; set; }
    }
}
