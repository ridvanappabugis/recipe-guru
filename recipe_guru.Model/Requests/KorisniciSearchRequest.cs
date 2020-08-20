using System;
namespace recipe_guru.Model.Requests
{
    public class KorisniciSearchRequest
    {
        public string Ime { get; set; }

        public string KorisnickoIme { get; set; }

        public string Prezime { get; set; }

        public int UlogaId { get; set; }
    }
}
