using System;
namespace recipe_guru.Model
{
    public partial class ReceptKorak
    {
        public int Id { get; set; }

        public int RedniBrojKoraka { get; set; }
        public string Deskripcija { get; set; }

        public int ReceptId { get; set; }
        public Recept Recept { get; set; }
    }
}
