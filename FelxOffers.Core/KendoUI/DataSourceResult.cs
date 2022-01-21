using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace FlexDataFeed.Core.KendoUI
{
    public class DataSourceResult
    {
        public object ExtraDat { get; set; }
        public IEnumerable Data { get; set; }
        public object Errors { get; set; }
        public int Total { get; set; }
    }
}
