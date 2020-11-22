using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents
{
    //Es ejemplo no es del curso sino de
    //https://app.pluralsight.com/guides/writing-custom-event-accessors-in-c
    public class Machine
    {
        private int _utilization = 0;
        private int _safeutil = 70;
        public delegate void StressLimitExceededEventHandler(object source, EventArgs e);
        public event StressLimitExceededEventHandler StressLimitExceeded
        {
            add
            {
                fieldStressLimitExceeded += value;
            }
            remove
            {
                fieldStressLimitExceeded -= value;
            }
        }
        private StressLimitExceededEventHandler fieldStressLimitExceeded;
        public virtual void OnStressLevelExceeded(EventArgs e)
        {
            fieldStressLimitExceeded?.Invoke(this, e);
        }
        public int Performance
        {
            get
            {
                return _utilization;
            }
        }
        static void MachineStressLimitExceeded(object source, EventArgs e)
        {
            Machine mechabot = (Machine)source;
            Console.WriteLine("Stress level warning ({0} %)", mechabot.Performance);


        }
        public void StressTest(int utilization)
        {
            int oldUtilization = _utilization;
            _utilization += utilization;

            if (oldUtilization <= _safeutil && _utilization > _safeutil)
                OnStressLevelExceeded(new EventArgs());
        }
        public static void MachineSample()
        {
            Machine mechabot = new Machine();
            mechabot.StressLimitExceeded += new StressLimitExceededEventHandler(MachineStressLimitExceeded);
            Console.WriteLine($"The utilization is {mechabot.Performance} %");
            mechabot.StressTest(60);
            Console.WriteLine($"The utilization is {mechabot.Performance} %");
            mechabot.StressTest(15);
            Console.WriteLine($"The utilization is {mechabot.Performance} %");            
        }
    }
}