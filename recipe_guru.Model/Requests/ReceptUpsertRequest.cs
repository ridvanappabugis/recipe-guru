using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace recipe_guru.Model.Requests
{
    public class ReceptUpsertRequest
    {
        public string Naziv { get; set; }

        public int? DuzinaPripreme { get; set; }

        public bool Public { get; set; } = true;

        public string Deskripcija { get; set; }

        public int? ImageResourceId { get; set; }

        public int? KnjigaRecepataId { get; set; }

        public int? KategorijaId { get; set; }

        public int? ReceptPregledId { get; set; }
    }
}
