using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Instagram.Models
{
    public class UpLoadFile
    {
        public static Cloudinary? cloudinary;
        public const string CLOUD_NAME = "dqnsplymn";
        public const string API_KEY = "279175116359664";
        public const string API_SECRET = "Oii8kBOmGAaOw_Wadnp0Rwc9oFk";
        public string? imagePath;
        public IFormFile? image;
        public void uploadImage(IFormFile? imageFile)
        {
            var acc = new Account("dqnsplymn", "279175116359664", "Oii8kBOmGAaOw_Wadnp0Rwc9oFk");
            var cloudinary = new Cloudinary(acc);
            using var stream = imageFile.OpenReadStream();
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(imageFile.FileName, stream)
            };
            cloudinary.Upload(uploadParams);
        }
      

    }
}
