﻿using Microsoft.AspNetCore.Mvc;
using NickChapsasCourse.Contracts.V1;
using NickChapsasCourse.Contracts.V1.Requests;
using NickChapsasCourse.Contracts.V1.Responses;
using NickChapsasCourse.Domain;
using NickChapsasCourse.Services;

namespace NickChapsasCourse.Controllers.V1
{
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        
        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet(ApiRoutes.Posts.GetAll)]
        public IActionResult GetAll()
        {
            return Ok(_postService.GetPosts());
        }

        [HttpGet(ApiRoutes.Posts.Get)]
        public IActionResult Get([FromRoute]Guid postId)
        {
            var post = _postService.GetPostById(postId);

            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }

        [HttpPost(ApiRoutes.Posts.Create)]
        public IActionResult Create([FromBody] CreatePostRequest postRequest)
        {
            Post post = new() { Id = postRequest.Id };

            if (post.Id == Guid.Empty)
            {
                post.Id = Guid.NewGuid();
            }

            _postService.GetPosts().Add(post);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.Posts.Get.Replace("{postId}", post.Id.ToString());

            var responce = new PostResponse { Id = post.Id };

            return Created(locationUri, responce);
        }
    }
}