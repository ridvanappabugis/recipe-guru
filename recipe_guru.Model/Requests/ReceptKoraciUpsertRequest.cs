using System;
using System.ComponentModel.DataAnnotations;

namespace recipe_guru.Model.Requests
{
    public class ReceptKoraciUpsertRequest
    {
        [Required]
        public int RedniBrojKoraka { get; set; }
        [Required]
        public string Deskripcija { get; set; }
        [Required]
        public int ReceptId { get; set; }
    }
}
