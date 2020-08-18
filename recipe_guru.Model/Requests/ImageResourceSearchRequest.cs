using System;
using System.ComponentModel.DataAnnotations;

namespace recipe_guru.Model.Requests
{
    public class ImageResourceSearchRequest
    {
        [Required]
        public int Id { get; set; }
    }
}
