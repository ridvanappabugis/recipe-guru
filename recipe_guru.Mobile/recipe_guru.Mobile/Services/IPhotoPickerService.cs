using System;
using System.IO;
using System.Threading.Tasks;

namespace recipe_guru.Mobile.Services
{
    public interface IPhotoPickerService
    {
        Task<Stream> GetImageStreamAsync();
    }
}
