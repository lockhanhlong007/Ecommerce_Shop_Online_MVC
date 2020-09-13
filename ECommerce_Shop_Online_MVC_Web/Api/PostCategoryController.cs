using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using ECommerce_Shop_Online_MVC_Model.Models;
using ECommerce_Shop_Online_MVC_Service.Interfaces;
using ECommerce_Shop_Online_MVC_Web.Infrastructure.Core;
using ECommerce_Shop_Online_MVC_Web.Infrastructure.Extensions;
using ECommerce_Shop_Online_MVC_Web.Models;

namespace ECommerce_Shop_Online_MVC_Web.Api
{
    [RoutePrefix("Api/PostCategory")]
    public class PostCategoryController : ApiControllerBase
    {
        private readonly IPostCategoryService _postCategoryService;
        private readonly IMapper _mapper;

        public PostCategoryController(IErrorService errorService, IPostCategoryService postCategoryService, IMapper mapper) :
            base(errorService)
        {
            this._postCategoryService = postCategoryService;
            _mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {

                var listPostCategoryViewModel = _mapper.ProjectTo<PostCategoryViewModel>(_postCategoryService.GetAll()).ToList();
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listPostCategoryViewModel);
                return response;
            });
        }


        [Route("{postCategoryViewModel}")]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage Create(HttpRequestMessage request, PostCategoryViewModel postCategoryViewModel)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    PostCategory newPostCategory = new PostCategory();
                    newPostCategory.UpdatePostCategory(postCategoryViewModel);

                    var category = _postCategoryService.Add(newPostCategory);
                    _postCategoryService.Save();

                    response = request.CreateResponse(HttpStatusCode.Created, category);

                }
                return response;
            });
        }

        [Route("{postCategoryViewModel}")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage Update(HttpRequestMessage request, PostCategoryViewModel postCategoryViewModel)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var postCategoryDb = _postCategoryService.GetById(postCategoryViewModel.Id);
                    postCategoryDb.UpdatePostCategory(postCategoryViewModel);
                    _postCategoryService.Update(postCategoryDb);
                    _postCategoryService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK);

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
                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    _postCategoryService.Delete(id);
                    _postCategoryService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }
    }
}