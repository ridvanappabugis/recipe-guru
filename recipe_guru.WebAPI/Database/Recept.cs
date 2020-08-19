using System;
using System.Collections.Generic;

namespace recipe_guru.WebAPI.Database
{
    public partial class Recept
    {
        public int Id { get; set; }

        public string Naziv { get; set; }
        public long BrojPregleda { get; set; }
        public int DuzinaPripreme { get; set; }
        public bool Public { get; set; }

        public int? ImageResourceId { get; set; }
        public virtual ImageResource? ImageResource { get; set; }

        public int KnjigaRecepataId { get; set; }
        public KnjigaRecepata KnjigaRecepata { get; set; }

        public int KategorijaId { get; set; }
        public virtual Kategorija Kategorija { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }
        public virtual ICollection<ReceptKorak> ReceptKoraci { get; set; }
        public virtual ICollection<ReceptSastojak> ReceptSastojci { get; set; }
    }
}
