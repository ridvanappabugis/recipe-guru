using System;
using System.ComponentModel.DataAnnotations;

namespace recipe_guru.Model.Requests
{
    public class RecommendSearchRequest
    {
        [Required]
        public int ReceptId { get; set; }

        [Required]
        public int KategorijaId { get; set; }
    }
}
