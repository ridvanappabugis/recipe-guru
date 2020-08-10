using System;
using System.Collections.Generic;

namespace recipe_guru.Model
{
    public partial class Korisnik
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string KorisnickoIme { get; set; }
        public bool? Status { get; set; }
        public ImageResource SlikaProfila { get; set; }

        public int UlogaId { get; set; }
        public Uloga Uloga { get; set; }
    }
}
