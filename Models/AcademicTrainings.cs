using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RiwiEmplea.Models.Enums;

namespace RiwiEmplea.Models
{
    public class AcademicTraining
    {
        public int Id { get; set; }
        public string? Institution { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public StateEnum State { get; set; }
        public int ResumeId { get; set; }
    }
}