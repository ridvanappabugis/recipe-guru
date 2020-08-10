using System;
namespace recipe_guru.WebAPI.Database
{
    public enum RatingMark
    {
        ONE_STAR, TWO_STAR, THREE_STAR, FOUR_STAR, FIVE_STAR
    }
    public class Ratings
    {
        public int Id { get; set; }
        public RatingMark Mark { get; set; }
        public string Comment { get; set; }
        public DateTime InsertTime { get; set; }

        public int KorisnikId { get; set; }
        public virtual Korisnici Korisnik { get; set; }

        public int ReceptId { get; set; }
        public virtual Recepti Recept { get; set; }
    }
}
