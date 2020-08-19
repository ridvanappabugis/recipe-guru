using System;
using System.ComponentModel.DataAnnotations;

namespace recipe_guru.Model.Requests
{
    public class ReceptPregledSearchRequest
    {
        [Required]
        public int ReceptId { get; set; }
    }
}
