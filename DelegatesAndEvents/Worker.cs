using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents
{
    public class Worker
    {

        //public event WorkPerformedHandler WorkPerformed;
        public event EventHandler<WorkPerformedEventArgs> WorkPerformed;
        public event EventHandler WorkCompleted;
        public void DoKork(int hours, WorkType workType)
        {
            for (int i=0;i<hours;i++)
            {
                System.Threading.Thread.Sleep(1000);
                this.OnWorkPerformed(null, new WorkPerformedEventArgs(i +1, workType));
            }
            OnWorkCompleted(this, EventArgs.Empty);
        }

        private void OnWorkPerformed(object sender, WorkPerformedEventArgs e)
        {
            //if(this.WorkCompleted!=null)
            //    this.WorkPerformed(8, WorkType.GenerateReports);            

            //WorkPerformedHandler del = this.WorkPerformed as WorkPerformedHandler;
            //if(del !=null)            
            //    del(8, WorkType.GenerateReports);            

            this.WorkPerformed?.Invoke(sender, e);
        }

        private void OnWorkCompleted(object sender, EventArgs e)
        {
            if (this.WorkCompleted != null)
                this.WorkCompleted(sender,e);
        }

    }
}