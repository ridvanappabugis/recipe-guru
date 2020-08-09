using System;
namespace recipe_guru.WebAPI.Database
{
    public partial class ImageResources
    {
        public long Id { get; set; }
        public byte[] ImageByteValue { get; set; }
    }
}
