﻿using System;

namespace recipe_guru.Model
{
    public partial class KorisnikUloga
    {
        public int KorisnikUlogaId { get; set; }
        public DateTime DatumIzmjene { get; set; }

        public int KorisnikId { get; set; }
        public Korisnik Korisnik { get; set; }

        public int UlogaId { get; set; }
        public Uloga Uloga { get; set; }
    }
}
