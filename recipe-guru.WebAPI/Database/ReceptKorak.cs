using System;
namespace recipe_guru.WebAPI.Database
{
    public partial class ReceptKorak
    {
        public int Id { get; set; }

        public int RedniBrojKoraka { get; set; }
        public string Deskripcija { get; set; }

        public int ReceptId { get; set; }
        public virtual Recept Recept { get; set; }
    }
}
