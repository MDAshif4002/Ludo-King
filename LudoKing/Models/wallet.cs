using System.ComponentModel.DataAnnotations;

namespace LudoKing.Models
{
    public class wallet
    {
        [Key]
        public int id { get; set; }
        public string? type { get; set; }
        public string? remark { get; set; }
        public string? amount { get; set; }
        public string? datetime { get; set; }
        public string? status { get; set; }
        public string? userid { get; set; }
        public string? txnid { get; set; }
        public string? screenshot { get; set; }
        public string? paymentrefno { get; set; }
    }
}
