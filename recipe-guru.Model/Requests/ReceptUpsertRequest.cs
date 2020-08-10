using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace recipe_guru.Model.Requests
{
    public class ReceptUpsertRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string Naziv { get; set; }

        public long BrojPregleda { get; set; } = 0;

        [Required]
        public int DuzinaPripreme { get; set; }

        public bool Public { get; set; } = true;

        public ImageResource GlavnaSlika { get; set; }

        [Required]
        public int KnjigaRecepataId { get; set; }

        [Required]
        public int KategorijaId { get; set; }
    }
}
