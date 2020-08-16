using System;
namespace recipe_guru.WebAPI.Database
{
    public partial class ImageResource
    {
        public int Id { get; set; }
        public byte[] ImageByteValue { get; set; }
    }
}
