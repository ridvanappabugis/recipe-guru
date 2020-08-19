using System;
using System.ComponentModel.DataAnnotations;

namespace recipe_guru.Model.Requests
{
    public class ReceptSastojakUpsertRequest
    {
        [Required]
        public string Kolicina { get; set; }
        [Required]
        public string Naziv { get; set; }
        [Required]
        public int ReceptId { get; set; }
    }
}
