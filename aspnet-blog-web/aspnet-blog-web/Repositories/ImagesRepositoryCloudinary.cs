using CloudinaryDotNet;
using System.ComponentModel;

namespace aspnet_blog_web.Repositories
{
    public class ImagesRepositoryCloudinary : IImagesRepository
    {
        private readonly Account account;
        public ImagesRepositoryCloudinary(IConfiguration configuration)
        {
            account = new Account(configuration.GetSection("Cloudinary")["CloudName"],
                configuration.GetSection("Cloudinary")["ApiKey"],
                configuration.GetSection("Cloudinary")["ApiSecret"]);
        }
        public async Task<string> UploadAsync(IFormFile file)
        {
            var client = new Cloudinary(account);
            var uploadFileResult = await client.UploadAsync(
                new CloudinaryDotNet.Actions.ImageUploadParams()
                {
                    File = new FileDescription(file.FileName, file.OpenReadStream()), 
                    DisplayName = file.FileName
                });
            if (uploadFileResult != null && uploadFileResult.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return uploadFileResult.SecureUri.ToString();
            }
            return null;
        }
    }
}
