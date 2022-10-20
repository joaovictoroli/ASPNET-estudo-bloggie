using aspnet_blog_web.Models.Domain;
using aspnet_blog_web.Models.ViewModel;
using aspnet_blog_web.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace aspnet_blog_web.Pages.Blog
{
    public class DetailsModel : PageModel
    {
        private readonly IBlogPostRepository blogPostRepository;
        private readonly IBlogPostLikeRepository blogPostLikeRepository;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IBlogPostCommentRepository blogPostCommentRepository;

        public BlogInPost BlogPost { get; set; }

        public List<BlogComment> Comments { get; set; }
        public int TotalLikes { get; set; }
        public bool IsLiked { get; set; }
        [BindProperty]
        public Guid BlogInPostId { get; set; }
        [BindProperty]
        [Required]
        [MinLength(1)]
        [MaxLength(200)]
        public string CommentDescription { get; set; }
       


        public DetailsModel(IBlogPostRepository blogPostRepository, 
            IBlogPostLikeRepository blogPostLikeRepository,
            SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager,
            IBlogPostCommentRepository blogPostCommentRepository)
        {
            this.blogPostRepository = blogPostRepository;
            this.blogPostLikeRepository = blogPostLikeRepository;
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.blogPostCommentRepository = blogPostCommentRepository;
        }

        public async Task<IActionResult> OnGet(string urlHandle)
        {
            await GetBlog(urlHandle);
            return Page();
        }


        public async Task<IActionResult> OnPost(string urlHandle)
        {
            if (ModelState.IsValid)
            {
                if (signInManager.IsSignedIn(User) && !string.IsNullOrWhiteSpace(CommentDescription))
                {
                    var userId = userManager.GetUserId(User);

                    var comment = new BlogPostComment()
                    {
                        BlogInPostId = BlogInPostId,
                        Description = CommentDescription,
                        DateAdded = DateTime.Now,
                        UserId = Guid.Parse(userId)
                    };

                    await blogPostCommentRepository.AddAsync(comment);
                }

                return RedirectToPage("/blog/details", new { urlHandle = urlHandle });
            }
            await GetBlog(urlHandle);
            return Page();
        }

        private async Task GetComments()
        {
            var blogPostComments = await blogPostCommentRepository.GetAllAsync(BlogPost.Id);

            var blogPostCommentsViewModel = new List<BlogComment>();
            foreach (var blogPostComment in blogPostComments)
            {
                blogPostCommentsViewModel.Add(new BlogComment
                {
                    DateAdded = blogPostComment.DateAdded,
                    Description = blogPostComment.Description,  
                    Username = (await userManager.FindByIdAsync(blogPostComment.UserId.ToString())).UserName,
                });
            }

            Comments = blogPostCommentsViewModel;
        }

        private async Task GetBlog(string urlHandle)
        {
            BlogPost = await blogPostRepository.GetAsync(urlHandle);

            if (BlogPost != null)
            {
                BlogInPostId = BlogPost.Id;
                if (signInManager.IsSignedIn(User))
                {
                    var likes = await blogPostLikeRepository.GetLikesForBlog(BlogPost.Id);
                    var userId = userManager.GetUserId(User);
                    IsLiked = likes.Any(x => x.UserId == Guid.Parse(userId));
                    await GetComments();
                }


                TotalLikes = await blogPostLikeRepository.GetTotalLikesForBlog(BlogPost.Id);
            }
        }
    }
}
