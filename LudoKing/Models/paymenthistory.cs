using System.ComponentModel.DataAnnotations;

namespace LudoKing.Models
{
    public class paymenthistory
    {
        [Key]
        public int id { get; set; }
        public string? paymentid { get; set; }
        public string? userid { get; set; }
        public string? date { get; set; }
        public string? amount { get; set; }
        public string? paymentstatus { get; set; }
    }
}
