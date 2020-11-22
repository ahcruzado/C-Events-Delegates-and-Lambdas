using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents
{
    public delegate int WorkPerformedHandler(object sender, WorkPerformedEventArgs e);

    public class WorkPerformedEventArgs:EventArgs
    {
        public WorkPerformedEventArgs(int hours, WorkType workType)
        {
            this.Hours = hours;
            this.WorkType = workType;
        }

        public int Hours{ get; set; }

        public WorkType WorkType { get; set; }
    }
}
