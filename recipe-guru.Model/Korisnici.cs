﻿using System;
using System.Collections.Generic;

namespace recipe_guru.Model
{
    public class Korisnici
    {
        public int KorisnikId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string KorisnickoIme { get; set; }
        public bool? Status { get; set; }

        public ICollection<KorisniciUloge> KorisniciUloge { get; set; }
    }
}
