using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents
{
    public delegate void WorkPerformedHandler(int hours, WorkType work);
    class Program
    {
        static void Main(string[] args)
        {
            WorkPerformedHandler del1 = new WorkPerformedHandler(WorkPerformed1);
            WorkPerformedHandler del2 = new WorkPerformedHandler(WorkPerformed2);
            WorkPerformedHandler del3 = new WorkPerformedHandler(WorkPerformed3);

            del1(1,WorkType.Golf);
            del2(2,WorkType.GenerateReports);
            DoWork(del1);

            Console.WriteLine(Environment.NewLine);
            del3 += del1;
            del3 += del2;
            del3(10, WorkType.GenerateReports);

            Console.WriteLine(Environment.NewLine);
            del3 = del1 + del2;            
            del3(10, WorkType.GenerateReports);


            Console.ReadKey();
        }

        static void DoWork(WorkPerformedHandler del)
        {
            //WorkPerformed1(3, WorkType.GoToMeetings);
            del(3, WorkType.GoToMeetings);
        }

        static void WorkPerformed1(int hours, WorkType work)
        {
            Console.WriteLine("WorkPermormed1 called " + hours.ToString());
        }

        static void WorkPerformed2(int hours, WorkType work)
        {
            Console.WriteLine("WorkPermormed2 called " + hours.ToString());
        }

        static void WorkPerformed3(int hours, WorkType work)
        {
            Console.WriteLine("WorkPermormed3 called " + hours.ToString());
        }

    }

    public enum WorkType
    {
        GoToMeetings,
        Golf,
        GenerateReports
    }
}
