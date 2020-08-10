﻿using System;
using System.Collections.Generic;

namespace recipe_guru.WebAPI.Database
{
    public partial class Korisnici
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string KorisnickoIme { get; set; }
        public string LozinkaHash { get; set; }
        public string LozinkaSalt { get; set; }
        public bool? Status { get; set; }

        public int UlogeId { get; set; }
        public Uloge Uloge { get; set; }
    }
}
