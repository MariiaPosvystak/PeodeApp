using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PeadeApp.Models
{
    public class Pyha
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nimetus on kohustuslik")]
        public string Nimetus { get; set; }
        [DataType(DataType.Date)]
        public DateTime Kuupaev { get; set; }
    }
}