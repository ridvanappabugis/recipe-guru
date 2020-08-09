using System;
namespace recipe_guru.Model
{
    public partial class ReceptKorak
    {
        public long ID { get; set; }

        public int RedniBrojKoraka { get; set; }
        public string Deskripcija { get; set; }

        public long ReceptId { get; set; }
        public Recept Recept { get; set; }
    }
}
