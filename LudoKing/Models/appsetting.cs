using System.ComponentModel.DataAnnotations;

namespace LudoKing.Models
{
    public class appsetting
    {
        [Key]
        public int id { get; set; }
        public string? webappstatus { get; set; }
        public string? undermaintenancemsg { get; set; }
        public string? terms { get; set; }
        public string? gamerules { get; set; }
        public string? whatsapplink { get; set; }
        public string? instalink { get; set; }
        public string? telegramlink { get; set; }
    }
}
