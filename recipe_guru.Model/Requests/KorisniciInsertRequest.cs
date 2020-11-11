using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace recipe_guru.Model.Requests
{
    public class KorisniciInsertRequest
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Deskripcija { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string KorisnickoIme { get; set; }
        public string Password { get; set; }
        public string PasswordPotvrda { get; set; }
        public int UlogaId { get; set; }
        public int? ImageResourceId { get; set; }

    }
}
