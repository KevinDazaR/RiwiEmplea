using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiwiEmplea.Models
{
    public class Resume
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateOnly BirthYear { get; set; }
        public string? PublicLink { get; set; }
        public string? AboutMy { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}