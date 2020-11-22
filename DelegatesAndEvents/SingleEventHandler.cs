using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents
{
    public class SingleEventHandler
    {
        //https://dailydotnettips.com/how-to-implement-event-accessors-and-single-handler-events/ 

        private event EventHandler myEvent;
        private EventHandler MyEventSingleHandler { get; set; }
        public event EventHandler MyEvent
        {
            add
            {
                if (MyEventSingleHandler != null)
                    this.myEvent -= this.MyEventSingleHandler;

                this.myEvent += value;
                this.MyEventSingleHandler = value;
            }
            remove
            {
                this.myEvent -= value;
                this.MyEventSingleHandler = null;
            }
        }

        void OnMyEvent()
        {
            if (this.myEvent != null)
                this.myEvent(this, EventArgs.Empty);
        }
    }
}
