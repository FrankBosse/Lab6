using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    internal class Event
    {
        //Properties of Event class
        public int EventNumber { get; set; }
        public string Location { get; set; }

        //Constructor of Event class, takes in two arguments to fill in the properties
        public Event(int EventNumber, string Location)
        {
            this.EventNumber = EventNumber;
            this.Location = Location;
        }
    }
}
