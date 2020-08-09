using System;
namespace recipe_guru.WebAPI.Database
{
    public partial class ReceptKoraci
    {
        public long Id { get; set; }

        public int RedniBrojKoraka { get; set; }
        public string Deskripcija { get; set; }


        public long ReceptId { get; set; }
        public Recepti Recept { get; set; }
    }
}
