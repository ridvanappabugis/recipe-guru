using System;
using System.Collections.Generic;

namespace recipe_guru.WebAPI.Database
{
    public partial class KnjigeRecepata
    {
        public KnjigeRecepata()
        {
            Recepti = new HashSet<Recepti>();
        }

        public int Id { get; set; }

        public string Naziv { get; set; }
        public bool Public { get; set; }

        public int KorisnikId { get; set; }
        public Korisnici Korisnik { get; set; }

        public virtual ICollection<Recepti> Recepti { get; set; }
    }
}
