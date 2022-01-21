using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexDataFeed.Core.Entity.Category
{
    public class ManualCategory
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string ImageUrl { get; set; }
        public string CategoryName { get; set; }
        public int CategoryStatus { get; set; }
        public int NetworkId { get; set; }
        public long AdvertiserId { get; set; }
        public long ProductId { get; set; }
    }
}
