using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using AutoMapper;
using ECommerce_Shop_Online_MVC_Model.Models;
using ECommerce_Shop_Online_MVC_Service.Interfaces;
using ECommerce_Shop_Online_MVC_Web.Infrastructure.Core;
using ECommerce_Shop_Online_MVC_Web.Infrastructure.Extensions;
using ECommerce_Shop_Online_MVC_Web.Models;

namespace ECommerce_Shop_Online_MVC_Web.Api
{
    [RoutePrefix("Api/Product")]
    public class ProductController : ApiControllerBase
    {
        #region Initialize
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IErrorService errorService, IProductService productService, IMapper mapper)
            : base(errorService)
        {
            _productService = productService;
            _mapper = mapper;
        }

        #endregion

        [HttpGet]
        [AllowAnonymous]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {

                var responseData = _mapper.ProjectTo<ProductViewModel>(_productService.GetAll()).ToList();

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }

        [Route("{id}")]
        [HttpGet]
        [AllowAnonymous]
        public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _productService.GetById(id);

                var responseData = _mapper.Map<Product, ProductViewModel>(model);

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }

        [Route("{keyword}-p.{page}-{pageSize}")]
        [HttpGet]
        [AllowAnonymous]
        public HttpResponseMessage GetAll(HttpRequestMessage request, string keyword, int page, int pageSize = 20)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;
                var model = _productService.GetAll(keyword);

                totalRow = model.Count();
                var query = model.OrderByDescending(x => x.DateCreated).Skip(page * pageSize).Take(pageSize);

                var responseData = _mapper.ProjectTo<ProductViewModel>(query);

                var paginationSet = new PaginationSet<ProductViewModel>()
                {
                    Items = responseData,
                    Page = page,
                    TotalCount = totalRow,
                    TotalPages = (int)Math.Ceiling((decimal)totalRow / pageSize)
                };
                var response = request.CreateResponse(HttpStatusCode.OK, paginationSet);
                return response;
            });
        }

        [Route("{productViewModel}")]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage Create(HttpRequestMessage request, ProductViewModel productViewModel)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var newProduct = new Product();
                    newProduct.UpdateProduct(productViewModel);
                    newProduct.DateCreated = DateTime.Now;
                    _productService.Add(newProduct);
                    _productService.Save();

                    var responseData = _mapper.Map<Product, ProductViewModel>(newProduct);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }

        [Route("{productViewModel}")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage Update(HttpRequestMessage request, ProductViewModel productViewModel)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var dbProduct = _productService.GetById(productViewModel.Id);

                    dbProduct.UpdateProduct(productViewModel);
                    dbProduct.DateModified = DateTime.Now;

                    _productService.Update(dbProduct);
                    _productService.Save();

                    var responseData = _mapper.Map<Product, ProductViewModel>(dbProduct);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }

        [Route("{id}")]
        [HttpDelete]
        [AllowAnonymous]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var oldProductCategory = _productService.Delete(id);
                    _productService.Save();

                    var responseData = _mapper.Map<Product, ProductViewModel>(oldProductCategory);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }
        [HttpDelete]
        [AllowAnonymous]
        public HttpResponseMessage DeleteMulti(HttpRequestMessage request, string checkedProducts)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var listProductCategory = new JavaScriptSerializer().Deserialize<List<int>>(checkedProducts);
                    foreach (var item in listProductCategory)
                    {
                        _productService.Delete(item);
                    }

                    _productService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK, listProductCategory.Count);
                }

                return response;
            });
        }
    }
}
