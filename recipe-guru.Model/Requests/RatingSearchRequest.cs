using System;
namespace recipe_guru.Model.Requests
{
    public class RatingSearchRequest
    {
        public long ReceptId { get; set; }

        public RatingMark Mark { get; set; }
    }
}
