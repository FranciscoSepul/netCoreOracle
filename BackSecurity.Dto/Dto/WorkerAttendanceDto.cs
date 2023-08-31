using System;
using System.Collections.Generic;

namespace BackSecurity.Dto
{
    public class WorkerAttendanceDto
    {
        public int Rut { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string DvRut { get; set; }
        public List<PlanShiftDto> PlanShifts { get; set; }
    }
    public class PlanShiftDto
    {
        public DateTime Date { get; set; }
        public int ShiftNumber { get; set; }
        public AttendanceDto Attendance { get; set; }
    }

    public class AttendanceDto
    {
        public string ShiftStart { get; set; }
        public string ShiftEnd { get; set; }
        public string BreakStart { get; set; }
        public string BreakEnd { get; set; }
    }
}