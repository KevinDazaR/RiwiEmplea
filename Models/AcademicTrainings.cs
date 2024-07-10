using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiwiEmplea.Models
{
    public class AcademicTrainings
    {
        public int Id { get; set; }
        public int ResumeId { get; set; }
        public string? Institution { get; set; }
        public string? Title { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public string? Description { get; set; }
    }
}