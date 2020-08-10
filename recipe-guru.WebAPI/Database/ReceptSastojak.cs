using System;
namespace recipe_guru.WebAPI.Database
{
    public partial class ReceptSastojak
    {
        public int Id { get; set; }

        public string Kolicina { get; set; }
        public string Naziv { get; set; }

        public int ReceptId { get; set; }
        public virtual Recept Recept { get; set; }
    }
}
