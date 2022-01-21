using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlexDataFeeds.Models.Api
{
    public class CategoryRequestModel
    {
        public string Apikey { get; set; }
        public string Page { get; set; }
        public string PageSize { get; set; }
        public int CategoryId { get; set; }

    }
}