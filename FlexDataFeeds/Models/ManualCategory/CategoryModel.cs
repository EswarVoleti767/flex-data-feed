using FelxDataFeed.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlexDataFeeds.Models.ManualCategory
{
    public class CategoryModel
    {
        public CategoryModel()
        {
            ImageList = new List<CategoryModel>();
        }
        public int Id { get; set; }
        public int? CategoryId { get; set; }
        public string ImageUrl { get; set; }
        public string DefaultImageUrl { get; set; }
        public string CategoryName { get; set; }
        public int NetworkId { get; set; }
        public long AdvertiserId { get; set; }
        public long ProductId { get; set; }
        public string DirtyImageId { get; set; }
        public int CategoryStatus { get; set; }
        public List<CategoryModel> ImageList { get; set; }
    }
}