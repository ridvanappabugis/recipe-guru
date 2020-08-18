using System;
using System.Collections.Generic;

namespace recipe_guru.WebAPI.Database
{
    public partial class KnjigaRecepata
    {
        public int Id { get; set; }

        public string Naziv { get; set; }
        public string Deskripcija { get; set; }
        public bool Public { get; set; }

        public int KorisnikId { get; set; }
        public virtual Korisnik Korisnik { get; set; }

        public int ImageResouceId { get; set; }
        public ImageResource ImageResource { get; set; }

        public virtual ICollection<Recept> Recepti { get; set; }
    }
}
