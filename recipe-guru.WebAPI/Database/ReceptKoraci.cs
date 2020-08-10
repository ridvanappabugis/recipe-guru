using System;
namespace recipe_guru.WebAPI.Database
{
    public partial class ReceptKoraci
    {
        public int Id { get; set; }

        public int RedniBrojKoraka { get; set; }
        public string Deskripcija { get; set; }


        public int ReceptId { get; set; }
        public Recepti Recept { get; set; }
    }
}
