using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RiwiEmplea.Models.Enums;

namespace RiwiEmplea.Models
{
    public class WorkExperience
    {
        public int Id { get; set; }
        public string? Company { get; set; }
        public string? Position { get; set; }
        public string? Description { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public StateEnum State { get; set; }
        public int ResumeId { get; set; }
    }
}