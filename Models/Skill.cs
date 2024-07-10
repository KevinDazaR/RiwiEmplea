using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiwiEmplea.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public int ResumeId { get; set; }
        public string? Ability { get; set; }
        public string? Level { get; set; }
    }
}