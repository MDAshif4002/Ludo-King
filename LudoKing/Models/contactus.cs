﻿using System.ComponentModel.DataAnnotations;

namespace LudoKing.Models
{
    public class contactus
    {
        [Key]
        public int id {  get; set; }
        public string? name { get; set; }
        public string? email { get; set; }
        public string? mobile { get; set; }
        public string? message { get; set; }
        public string? datetime { get; set; }
        public bool? status { get; set; }
    }
}
