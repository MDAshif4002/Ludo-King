using System.ComponentModel.DataAnnotations;

namespace LudoKing.Models
{
    public class deposited
    {
        [Key]
        public int id { get; set; }
        public string? name { get; set; }
        public string? mobile { get; set; }
        public string? username { get; set; }
        public string? status { get; set; }
        public string? mode { get; set; }
        public string? transactionid { get; set; }
        public string? screenshot { get; set; }
        public string? datetime { get; set; }
    }
}
