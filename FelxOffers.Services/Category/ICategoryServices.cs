using FlexDataFeed.Core.Entity.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexDataFeed.Services.Category
{
    public interface ICategoryServices
    {
        List<ManualCategory> GetAllManualCategories(int? categoryId=null,int categoryStatus=0);
        ManualCategory GetManualCategoryById(int id);
        void UpdateProductSkuCategory(ManualCategory manualCategory);
        void CreateCategory(ManualCategory manualCategory);
        void UpdateManualCategory(ManualCategory manualCategory);
        void DeleteManualCategory(int id);
    }
}
