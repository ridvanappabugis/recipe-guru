using System;
namespace recipe_guru.Model
{
    public enum RatingMark
    {
        ONE_STAR, TWO_STAR, THREE_STAR, FOUR_STAR, FIVE_STAR
    }
    public partial class Rating
    {

        public int Id { get; set; }
        public RatingMark Mark { get; set; }
        public string Comment { get; set; }
        public DateTime InsertTime { get; set; }

        public int KorisnikId { get; set; }

        public int ReceptId { get; set; }
    }
}
