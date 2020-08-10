using System;
using System.Collections.Generic;

namespace recipe_guru.WebAPI.Database
{
    public partial class Recepti
    {
        public Recepti() {
            Ratings = new HashSet<Ratings>();
            ReceptKoraci = new HashSet<ReceptKoraci>();
        }

        public int Id { get; set; }

        public string Naziv { get; set; }
        public long BrojPregleda { get; set; }
        public int DuzinaPripreme { get; set; }
        public bool Public { get; set; }
        public ImageResources GlavnaSlika { get; set; }

        public int KnjigaRecepataId { get; set; }
        public KnjigeRecepata KnjigaRecepata { get; set; }

        public int KategorijeId { get; set; }
        public virtual Kategorije Kategorije { get; set; }

        public virtual ICollection<Ratings> Ratings { get; set; }
        public virtual ICollection<ReceptKoraci> ReceptKoraci { get; set; }
        public virtual ICollection<ReceptSastojci> ReceptSastojci { get; set; }
    }
}
