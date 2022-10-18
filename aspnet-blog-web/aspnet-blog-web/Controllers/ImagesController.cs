using aspnet_blog_web.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace aspnet_blog_web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ImagesController : Controller
    {
        private readonly IImagesRepository imageRepository; 
        public ImagesController(IImagesRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }
        [HttpPost]
        public async Task<IActionResult> UploadAsync(IFormFile file)
        {           
            var imageUrl = await imageRepository.UploadAsync(file);

            if (imageUrl == null)
            {
                Console.WriteLine("Eai fi");
                return Problem("Something went wrong!", null, (int)HttpStatusCode.InternalServerError);
            }

            return Json(new { link = imageUrl });
            
        }
    }
}
