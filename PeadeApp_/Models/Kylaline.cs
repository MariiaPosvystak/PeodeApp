using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PeadeApp.Models
{
    public class Kylaline
    {
        public int Id { get; set; }
        public string Nimi { get; set; }
        public string Email { get; set; }
        public bool OnKutse { get; set; }
        public int PyhaId { get; set; }
    }
}