using System.ComponentModel.DataAnnotations;

namespace LudoKing.Models
{
    public class adminincome
    {
        [Key]
        public int id { get; set; }
        public string? name { get; set; }
        public string? email { get; set; }
        public string? incomemode { get; set; }
        public string? incomeamount { get; set; }
        public string? paymentfrequency { get; set; }
        public string? datetime { get; set; }
        public string? txnid { get; set; }
    }
}
