using System;
using System.ComponentModel.DataAnnotations;

namespace recipe_guru.Model.Requests
{
    public class RatingUpsertRequest
    {
        [Required]
        public RatingMark Mark { get; set; }
        public string Comment { get; set; }

        [Required]
        public DateTime InsertTime { get; set; }

        [Required]
        public int KorisnikId { get; set; }

        [Required]
        public int ReceptId { get; set; }
    }
}
