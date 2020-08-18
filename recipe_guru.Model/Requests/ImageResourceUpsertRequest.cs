using System;
using System.ComponentModel.DataAnnotations;

namespace recipe_guru.Model.Requests
{
    public class ImageResourceUpsertRequest
    {
        [Required]
        public byte[] ImageByteValue { get; set; }
    }
}
