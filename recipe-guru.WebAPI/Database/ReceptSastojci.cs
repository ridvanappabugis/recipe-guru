using System;
namespace recipe_guru.WebAPI.Database
{
    public class ReceptSastojci
    {
        public long Id { get; set; }

        public string Kolicina { get; set; }
        public string Naziv { get; set; }

        public long ReceptId { get; set; }
        public Recepti Recept { get; set; }
    }
}
