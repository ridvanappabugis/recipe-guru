using System;
using System.Collections.Generic;

namespace recipe_guru.Model
{
    public partial class KnjigaRecepata
    {
        public int Id { get; set; }

        public string Naziv { get; set; }
        public bool Public { get; set; }

        public int KorisnikId { get; set; }
        public Korisnik Korisnik { get; set; }

        public virtual ICollection<Recept> Ratings { get; set; }
    }
}
