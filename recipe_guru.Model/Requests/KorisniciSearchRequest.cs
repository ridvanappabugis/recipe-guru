using System;
namespace recipe_guru.Model.Requests
{
    public class KorisniciSearchRequest
    {
        public string Ime { get; set; }

        public string Prezime { get; set; }

        public bool IsUlogeLoadingEnabled { get; set; }
    }
}
