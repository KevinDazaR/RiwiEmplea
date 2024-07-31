using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RiwiEmplea.Models.Enums;

namespace RiwiEmplea.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public LevelEnum Level { get; set; }
        public StateEnum State { get; set; }
        public int ResumeId { get; set; }
    }
}