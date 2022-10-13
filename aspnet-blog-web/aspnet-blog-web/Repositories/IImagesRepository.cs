namespace aspnet_blog_web.Repositories
{
    public interface IImagesRepository
    {
        Task<string> UploadAsync(IFormFile file);
    }
}
