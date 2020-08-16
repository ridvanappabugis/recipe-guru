using System;
using System.ComponentModel.DataAnnotations;

namespace recipe_guru.Model.Requests
{
    public class ReceptKoraciSearchRequest
    {
        [Required]
        public int ReceptId { get; set; }
    }
}
