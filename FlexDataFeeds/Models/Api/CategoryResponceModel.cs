using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlexDataFeeds.Models.Api
{
    public class CategoryResponceModel
    {
        public string pid { get; set; }
        public string imageUrl { get; set; }
        public string primaryCategory { get; set; }
        public object secondaryCategory { get; set; }
        public int categoryId { get; set; }
        public string shortDescription { get; set; }
        public string description { get; set; }
    }
}