using System;
using System.Collections.Generic;

namespace recipe_guru.WebAPI.Services
{
    public interface IRecommenderService
    {
        public List<Model.Recept> RecommendProduct(int receptId, int kategorijaId);
    }
}
