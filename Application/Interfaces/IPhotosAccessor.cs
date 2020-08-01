namespace Application.Interfaces
{
    using Photos;
    using Microsoft.AspNetCore.Http;

    public interface IPhotosAccessor
    {
        PhotoUploadResult AddPhoto(IFormFile file);
        string DeletePhoto(string publicId);
    }
}
