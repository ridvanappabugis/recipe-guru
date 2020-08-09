using System;
using System.Collections.Generic;

namespace recipe_guru.Model
{
    public partial class Recept
    {
        public long ID { get; set; }

        public string Naziv { get; set; }
        public long BrojPregleda { get; set; }
        public string DuzinaPripreme { get; set; }
        public bool Public { get; set; }
        public ImageResource GlavnaSlika { get; set; }

        public ICollection<string> PotrebniSastojci { get; set; }

        public long KnjigaRecepataId { get; set; }
        public KnjigaRecepata KnjigaRecepata { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }
        public virtual ICollection<Kategorija> Kategorije { get; set; }
        public virtual ICollection<ReceptKorak> ReceptKoraci { get; set; }
    }
}
