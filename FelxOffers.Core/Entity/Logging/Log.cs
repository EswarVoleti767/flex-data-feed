using FlexDataFeed.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexDataFeed.Core.Entity.Logging
{
    public class Log : BaseEntity
    {
        public int LogLevelId { get; set; }
        public string Entity { get; set; }
        public string EntityId { get; set; }
        public string ShortMessage { get; set; }
        public string FullMessage { get; set; }
        public LogLevel LogLevel
        {
            get
            {
                return (LogLevel)this.LogLevelId;
            }
            set
            {
                this.LogLevelId = (int)value;
            }
        }
    }
}
