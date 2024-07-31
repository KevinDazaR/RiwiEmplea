using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RiwiEmplea.Models.Enums;

namespace RiwiEmplea.Models
{
    public class Resume
    {
        public int Id { get; set; }
        public DateOnly Birthdate { get; set; }
        public string? PublicLink { get; set; }
        public string? AboutMe { get; set; }
        public DateTime CreatedAt { get; set; }
        public StateEnum State { get; set; }
        public int UserId { get; set; }
    }
}