using FlexDataFeed.Core.Entity.Category;
using FlexDataFeed.Data;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Configuration;

namespace FlexDataFeed.Services.Category
{
    public class CategoryServices : ICategoryServices
    {
        #region Constants
        private readonly IDapperRepository _categoryRepository;
        #endregion

        #region Constructor
        public CategoryServices(IDapperRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }
        #endregion

        #region Utilities

        #endregion

        #region Methods
        public List<ManualCategory> GetAllManualCategories(int? categoryId = null, int categoryStatus = 0)
        {
            var param = new { CategoryId = categoryId , CategoryStatus = categoryStatus };
            var inspections = _categoryRepository.ExecuteProcedure<ManualCategory>("[GetAllCategories]", param).ToList();
            return inspections;
        }
        public ManualCategory GetManualCategoryById(int id)
        {
            var param = new { Id = id };
            var summary = _categoryRepository.ExecuteProcedure<ManualCategory>("[GetCategory]", param).FirstOrDefault();
            return summary;
        }
        public void UpdateProductSkuCategory(ManualCategory manualCategory)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ProductSkuJobData"].ConnectionString;
                var param = new
                {
                    NetworkId = manualCategory.NetworkId,
                    AdvertiserId = manualCategory.AdvertiserId,
                    ProductId = manualCategory.ProductId,
                    CategoryStatus = manualCategory.CategoryStatus
                };
                _categoryRepository.ExecuteProcedure<ManualCategory>(connectionString, "[UpdateProductSkuCategoryStatus]", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void CreateCategory(ManualCategory manualCategory)
        {
            var param = new { manualCategory };
            _categoryRepository.ExecuteProcedure<ManualCategory>("[CreateCategory]", param);
        }
        public void UpdateManualCategory(ManualCategory manualCategory)
        {
            var param = new { manualCategory };
            _categoryRepository.ExecuteProcedure<ManualCategory>("[UpdateCategory]", param).FirstOrDefault();
        }
        public void DeleteManualCategory(int id)
        {
            _categoryRepository.Delete(id, "[DeleteCategory]");
        }

        #endregion
    }
}
