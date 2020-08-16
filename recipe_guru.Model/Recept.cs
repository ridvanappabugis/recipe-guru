using System;
using System.Collections.Generic;

namespace recipe_guru.Model
{
    public partial class Recept
    {
        public int Id { get; set; }

        public string Naziv { get; set; }
        public long BrojPregleda { get; set; }
        public int DuzinaPripreme { get; set; }
        public bool Public { get; set; }
        public ImageResource GlavnaSlika { get; set; }

        public int KnjigaRecepataId { get; set; }

        public int KategorijaId { get; set; }
    }
}
