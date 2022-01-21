using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexDataFeed.Core.KendoUI
{
    public class DataSourceRequest
    {
        public DataSourceRequest()
        {
            this.Page = 1;
            this.PageSize = 15;
        }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
