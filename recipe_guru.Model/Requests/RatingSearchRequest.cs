using System;
namespace recipe_guru.Model.Requests
{
    public class RatingSearchRequest
    {
        public int ReceptId { get; set; }

        public int KorisnikId { get; set; }

        public RatingMark? Mark { get; set; }
    }
}
