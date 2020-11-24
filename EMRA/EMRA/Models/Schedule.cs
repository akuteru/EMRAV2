using System;
using System.Collections.Generic;
using System.Text;

namespace EMRA.Models
{
    public class Schedule
    {
        public long ID { get; set; }
        public DateTime ScheduleDate { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
