using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace recipe_guru.Model.Requests
{
    public class KnjigaRecepataInsertRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string Naziv { get; set; }

        [Required(AllowEmptyStrings = false)]
        public bool Public { get; set; }

        [Required(AllowEmptyStrings = false)]
        public long KorisnikId { get; set; }

        public ICollection<Recept> Recepti { get; set; } = new List<Recept>();
    }
}
