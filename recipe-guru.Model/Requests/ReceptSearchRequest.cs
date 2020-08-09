using System;
namespace recipe_guru.Model.Requests
{
    public class ReceptSearchRequest
    {
        public string Naziv { get; set; }

        public long BrojPregleda { get; set; }

        public string DuzinaPripreme { get; set; }

        public int AverageRating { get; set; }
    }
}
