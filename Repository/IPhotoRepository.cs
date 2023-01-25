using CloudinaryDotNet.Actions;

namespace ValiantApp.Repository
{
    public interface IPhotoRepository
    {
        Task<ImageUploadResult> AddPhotoAsync(IFormFile file);
        Task<DeletionResult> DeletePhotoAsync(string PID);
    }
}
