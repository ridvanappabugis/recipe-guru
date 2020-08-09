using System;
namespace recipe_guru.Model.Requests
{
    public class ReceptKoraciUpsertRequest
    {
        public int RedniBrojKoraka { get; set; }
        public string Deskripcija { get; set; }
        public long ReceptId { get; set; }
    }
}
