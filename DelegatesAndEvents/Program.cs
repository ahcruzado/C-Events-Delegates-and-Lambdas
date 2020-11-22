using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents
{    
    class Program
    {
        static void Main(string[] args)
        {
            WorkPerformedHandler del1 = new WorkPerformedHandler(WorkPerformed1);
            WorkPerformedHandler del2 = new WorkPerformedHandler(WorkPerformed2);
            WorkPerformedHandler del3 = new WorkPerformedHandler(WorkPerformed3);

            del1(null, new WorkPerformedEventArgs(1,WorkType.Golf));
            del2(null, new WorkPerformedEventArgs(2,WorkType.GenerateReports));
            DoWork(del1);

            Console.WriteLine(Environment.NewLine);
            del3 += del1;
            del3 += del2;
            del3(null, new WorkPerformedEventArgs(10, WorkType.GenerateReports));

            Console.WriteLine(Environment.NewLine);
            del3 = del1 + del2;
            int finalHours = del3(null, new WorkPerformedEventArgs(10, WorkType.GenerateReports));
            Console.WriteLine("finalHours:" + finalHours.ToString());
            
            Machine.MachineSample();
            WorkerClassSample();
            Console.ReadKey();
        }

        static void WorkerClassSample()
        {
            var worker = new Worker();

            //worker.WorkPerformed += new EventHandler<WorkPerformedEventArgs>(Worker_WorkPerformed);
            
            worker.WorkPerformed += delegate(object sender, WorkPerformedEventArgs e)
                                    {
                                        Console.WriteLine(e.Hours + " " + e.WorkType);
                                    };

            worker.WorkCompleted += Worker_WorkCompleted;
            worker.WorkCompleted += (sender, e) =>
                                    {
                                        Console.WriteLine("Work Completed");
                                    };

            worker.DoKork(8, WorkType.GoToMeetings);
        }

        private static void Worker_WorkPerformed(object sender, WorkPerformedEventArgs e)
        {
            Console.WriteLine(e.Hours + " " + e.WorkType);
        }

        private static void Worker_WorkCompleted(object sender, EventArgs e)
        {
            Console.WriteLine("Work Completed");
        }

        static void DoWork(WorkPerformedHandler del)
        {
            //WorkPerformed1(3, WorkType.GoToMeetings);
            del(null, new WorkPerformedEventArgs(3, WorkType.GoToMeetings));
        }

        static int WorkPerformed1(object sender, WorkPerformedEventArgs e)
        {
            Console.WriteLine("WorkPermormed1 called " + e.Hours.ToString());
            return e.Hours + 1;
        }

        static int WorkPerformed2(object sender, WorkPerformedEventArgs e)
        {
            Console.WriteLine("WorkPermormed2 called " + e.Hours.ToString());
            return e.Hours + 2;
        }

        static int WorkPerformed3(object sender, WorkPerformedEventArgs e)
        {
            Console.WriteLine("WorkPermormed3 called " + e.Hours.ToString());
            return e.Hours + 3;
        }
        
    }

    public enum WorkType
    {
        GoToMeetings,
        Golf,
        GenerateReports
    }
}
