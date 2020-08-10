using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace recipe_guru.Model.Requests
{
    public class KnjigaRecepataUpsertRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string Naziv { get; set; }

        public bool Public { get; set; } = true;

        [Required]
        public int KorisnikId { get; set; }
    }
}
