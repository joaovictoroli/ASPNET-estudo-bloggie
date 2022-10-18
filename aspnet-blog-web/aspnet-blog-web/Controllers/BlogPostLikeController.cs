using aspnet_blog_web.Models.ViewModel;
using aspnet_blog_web.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace aspnet_blog_web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogPostLikeController : Controller
    {
        private readonly IBlogPostLikeRepository blogPostLikeRepository;

        public BlogPostLikeController(IBlogPostLikeRepository blogPostLikeRepository)
        {
            this.blogPostLikeRepository = blogPostLikeRepository;
        }

        [Route("Add")]
        [HttpPost]
        public async Task<IActionResult> AddLike([FromBody] AddBlogPostLikeRequest addBlogPostLike)
        {
            await blogPostLikeRepository.AddLikesForBlog(addBlogPostLike.BlogInPostId
                                                    , addBlogPostLike.UserId);
            return Ok();
        }

        [Route("{blogInPostId:Guid}/totalLikes")]
        [HttpGet]
        public async Task<IActionResult> GetTotalLikes([FromRoute] Guid blogInPostId)
        {
            var totaLikes = await blogPostLikeRepository.GetTotalLikesForBlog(blogInPostId);
            Console.WriteLine(totaLikes);
            return Ok(totaLikes);
        }

    }
}
