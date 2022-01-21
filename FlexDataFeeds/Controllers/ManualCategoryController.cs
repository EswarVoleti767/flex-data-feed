using FelxDataFeed.Core.Common;
using FlexDataFeed.Core.Entity.Category;
using FlexDataFeed.Core.KendoUI;
using FlexDataFeed.Services.Category;
using FlexDataFeeds.Models.Api;
using FlexDataFeeds.Models.ManualCategory;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace FlexDataFeeds.Controllers
{
    public class ManualCategoryController : Controller
    {
        #region Constants
        private readonly ICategoryServices _categoryServices;
        #endregion

        #region Constructor
        public ManualCategoryController(ICategoryServices categoryServices)
        {
            this._categoryServices = categoryServices;
        }
        #endregion

        #region Utilities

        public CategoryModel GetCategories(CategoryRequestModel requestModel)
        {
            var model = new CategoryModel();
            var result = GetAllApiCategories(requestModel);
            var data = result.Select(c => new CategoryModel
            {
                CategoryId = c.categoryId,
                ImageUrl = c.imageUrl
            }).ToList().Take(1);
            model.ImageList = data.ToList();
            model.DefaultImageUrl = model.ImageList.Select(d => d.ImageUrl).FirstOrDefault();
            return model;
        }
        public List<CategoryResponceModel> GetAllApiCategories(CategoryRequestModel categoryRequestModel)
        {
            string response = string.Empty;
            string endpointUrl = string.Empty;
            string apikey = string.Empty;
            string orgid = string.Empty;
            String post_data = string.Empty;
            int categroryId = categoryRequestModel.CategoryId > 0 ? categoryRequestModel.CategoryId : 160;
            var rootObject = new List<CategoryResponceModel>();
            try
            {
                endpointUrl = $"https://api.flexoffers.com/products/getAll?page=1&pageSize=10&catId={categroryId}";
                apikey = "7c124590-8c3a-4d91-9dc8-0d9f809af2c1";
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(endpointUrl);
                webRequest.ContentType = "application/json";
                webRequest.MediaType = "application/json";
                webRequest.Accept = "application/json";
                webRequest.Method = "GET";
                webRequest.Headers.Add("apikey", apikey);
                using (var webResponse = (HttpWebResponse)webRequest.GetResponse())
                {
                    if (webResponse.StatusCode == HttpStatusCode.OK)
                    {
                        using (var streamReader = new StreamReader(webResponse.GetResponseStream()))
                        {
                            response = streamReader.ReadToEnd();
                            rootObject = JsonConvert.DeserializeObject<List<CategoryResponceModel>>(response);
                        }
                    }
                }
            }
            catch (WebException)
            {

            }
            catch (Exception)
            {


                string message = DateTime.Now + " : " + string.Format("Error while calling Api:{0}", endpointUrl);
            }
            return rootObject;
        }

        public CategoryModel GetAllCategories(CategoryModel model)
        {
            var result = _categoryServices.GetAllManualCategories(categoryId: model.CategoryId, categoryStatus: model.CategoryStatus);
            if (result?.Count > 0)
            {
                var data = result.Select(c => new CategoryModel
                {
                    CategoryId = c.CategoryId,
                    ImageUrl = c.ImageUrl,
                    CategoryName = c.CategoryName,
                    NetworkId = c.NetworkId,
                    AdvertiserId = c.AdvertiserId,
                    ProductId = c.ProductId,

                }).ToList();
                model.ImageList = data.ToList();
                var categoryInfo = data.FirstOrDefault();
                model.DefaultImageUrl = categoryInfo.ImageUrl;
                model.CategoryName = categoryInfo.CategoryName;
            }
            return model;
        }

        #endregion

        #region Methods

        #region Categorizer Cleaner

        #region List

        [HttpGet]
        public ActionResult List()
        {
            var model = new CategoryModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult List(CategoryModel model)
        {
            var categoryModel = new CategoryModel
            {
                CategoryId = model.CategoryId
            };
            model = GetAllCategories(categoryModel);
            return View(model);
        }

        #endregion

        #region Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(CategoryModel model)
        {

            return View();
        }
        #endregion

        #region Edit
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = new CategoryModel();
            var category = _categoryServices.GetManualCategoryById(id);
            if (category != null)
            {
                model = new CategoryModel
                {
                    Id = category.Id,
                    CategoryId = category.CategoryId,
                    ImageUrl = category.ImageUrl
                };
                return View(model);
            }
            return RedirectToAction("List");
        }
        [HttpPost]
        public ActionResult Edit(CategoryModel model)
        {
            var category = new ManualCategory
            {
                Id = model.Id,
                CategoryId = model.CategoryId.GetValueOrDefault(),
                ImageUrl = model.ImageUrl
            };
            _categoryServices.UpdateManualCategory(category);
            return View(model);
        }

        #endregion

        #region MarkDirty
        [HttpPost]
        public JsonResult MarkDirty(CategoryModel model)
        {
            bool isUpdate = false;
            try
            {
                var ids = model.DirtyImageId.Split(new[] { '_' }, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(x => Convert.ToInt64(x))
                                    .ToArray();

                var manualCategory = new ManualCategory
                {
                    NetworkId = Convert.ToInt32(ids[0]),
                    AdvertiserId = ids[1],
                    ProductId = ids[2],
                    CategoryStatus = model.CategoryStatus
                };

                _categoryServices.UpdateProductSkuCategory(manualCategory);
                isUpdate = true;
            }
            catch (Exception)
            {
            }

            return Json(new { success = isUpdate });
        }

        [HttpPost]
        public JsonResult ManualUpdate(CategoryModel model)
        {
            bool isUpdate = false;
            try
            {
                var ids = model.DirtyImageId.Split(new[] { '_' }, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(x => Convert.ToInt64(x))
                                    .ToArray();

                var manualCategory = new ManualCategory
                {
                    NetworkId = Convert.ToInt32(ids[0]),
                    AdvertiserId = ids[1],
                    ProductId = ids[2],
                    CategoryStatus = model.CategoryStatus
                };

                _categoryServices.UpdateProductSkuCategory(manualCategory);
                isUpdate = true;
            }
            catch (Exception)
            {
            }

            return Json(new { success = isUpdate });
        }
        #endregion
        #endregion

        #region Manual/ML Categorizer

        #region List

        [HttpGet]
        public ActionResult ManualCategorizerList()
        {
            //var requestModel = new CategoryRequestModel();
            //var model = GetCategories(requestModel);
            //return View(model);
            var model = new CategoryModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult ManualCategorizerList(CategoryModel model)
        {
            var categoryModel = new CategoryModel
            {
                CategoryId = model.CategoryId,
                CategoryStatus = (int)CategoryStatus.Dirty
            };
            model = GetAllCategories(categoryModel);
            return View(model);
        }

        #endregion

        #endregion

        #endregion


    }
}