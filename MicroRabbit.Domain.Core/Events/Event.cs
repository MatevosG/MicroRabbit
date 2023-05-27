using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroRabbit.Domain.Core.Events
{
    public class Event
    {
        public DateTime Timestamp { get; set; }
        public Event()
        {
            Timestamp = DateTime.Now;
        }
    }
}
