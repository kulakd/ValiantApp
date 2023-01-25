using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.Extensions.Options;
using ValiantApp.Other;

namespace ValiantApp.Repository
{
    public class PhotoRepository : IPhotoRepository
    {
        private readonly Cloudinary cloud;
        public PhotoRepository(IOptions<CloudinaryS> option)
        {
            var account = new Account(
                option.Value.CloudName,
                option.Value.ApiKey,
                option.Value.ApiSecret);
            cloud = new Cloudinary(account);
        }
        public async Task<ImageUploadResult> AddPhotoAsync(IFormFile file)
        {
            var Uploud = new ImageUploadResult();
            if(file.Length >0)
            {
                using var stream = file.OpenReadStream();
                var UploadR = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    Transformation = new Transformation().Height(600).Width(600).Crop("fill").Gravity("face")
                };
                Uploud = await cloud.UploadAsync(UploadR);
            }
            return Uploud;
        }

        public async Task<DeletionResult> DeletePhotoAsync(string PID)
        {
            var Delete = new DeletionParams(PID);
            var delete = await cloud.DestroyAsync(Delete);
            return delete;
        }
    }
}
