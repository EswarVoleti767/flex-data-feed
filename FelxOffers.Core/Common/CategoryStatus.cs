using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FelxDataFeed.Core.Common
{
    public enum CategoryStatus
    {
        Default = 0,
        Processed = 1,
        ManuallyProcessed = 2,
        Dirty = 3
    }
}
