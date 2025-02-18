using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace LudoKing.Models
{
    
    public class registration
    {
        [Key]
        public int id { get; set; }
        public string? name { get; set; }
        public string? email { get; set; }
        public string? mobile { get; set; }
        public string? otp { get; set; }
        public bool? otpstatus { get; set; }
        public string? walletbalance { get; set; }
        public string? datetime { get; set; }
        public bool? blockstatus { get; set; }
        public string? photo { get; set; }
    }
}
