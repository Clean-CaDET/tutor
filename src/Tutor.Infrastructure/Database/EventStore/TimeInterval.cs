using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutor.Infrastructure.Database.EventStore
{
    public class TimeInterval
    {
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
    }
}
