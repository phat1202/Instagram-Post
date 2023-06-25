using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Instagram.Models
{
    public class UpLoadFile
    {
        public static Cloudinary? cloudinary;

        public int uploadImage(IFormFile? imageFile)
        {
            var acc = new Account("dqnsplymn", "279175116359664", "Oii8kBOmGAaOw_Wadnp0Rwc9oFk");
            var cloudinary = new Cloudinary(acc);
            using var stream = imageFile.OpenReadStream();
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(imageFile.FileName, stream)
            };
            var result = cloudinary.Upload(uploadParams);
            var Path = new Image()
            {
                Url = result.SecureUrl.OriginalString.ToString()
            };
            var db = new InsContext();
            db.Add(Path);
            db.SaveChanges();
            var imageid = Path.ImageId;
            return imageid.Value;
        }
      

    }
}
