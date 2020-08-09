using System;
namespace recipe_guru.Model.Requests
{
    public class RatingUpsertRequest
    {
        public RatingMark Mark { get; set; }
        public string Comment { get; set; }
        public DateTime InsertTime { get; set; }

        public long KorisnikID { get; set; }

        public long ReceptID { get; set; }
    }
}
