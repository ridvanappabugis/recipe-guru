using System;
namespace recipe_guru.WebAPI.Database
{
    public class ReceptPregled
    {
        public int Id { get; set; }

        public int BrojPregleda { get; set; }

        public int ReceptId { get; set; }
        public virtual Recept Recept { get; set; }
    }
}
