using System;
using System.ComponentModel.DataAnnotations;

namespace recipe_guru.Model.Requests
{
    public class ReceptPregledUpsertRequest
    {
        [Required]
        public int BrojPregleda { get; set; }
    }
}
