using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using recipe_guru.WebAPI.Database;

namespace recipe_guru.WebAPI.Services
{
    public class RecommenderService : IRecommenderService
    {
        protected recipeGuruContext db;
        protected IMapper _mapper;

        public RecommenderService(recipeGuruContext context, IMapper mapper)
        {
            db = context;
            _mapper = mapper;
        }

        public List<Model.Recept> RecommendProduct(int receptId, int kategorijaId)
        {
            var x = LoadSimilar(receptId, kategorijaId);
            return _mapper.Map<List<Model.Recept>>(x);
        }

        Dictionary<int, List<Database.Rating>> ratingsDictionary = new Dictionary<int, List<Database.Rating>>();

        private List<Database.Recept> LoadSimilar(int receptId, int kategorijaId)
        {
            LoadRecepts(receptId, kategorijaId);
            List<Database.Rating> ratingsOfThis = db.Ratings.Where(x => x.ReceptId == receptId).OrderBy(x => x.KorisnikId).ToList();

            List<Database.Rating> ratings1 = new List<Database.Rating>();
            List<Database.Rating> ratings2 = new List<Database.Rating>();
            List<Database.Recept> recomendedRecepts = new List<Database.Recept>();

            foreach (var item in ratingsDictionary)
            {
                foreach (Database.Rating rating in ratingsOfThis)
                {
                    if (item.Value.Where(x => x.KorisnikId == rating.KorisnikId).Count() > 0)
                    {
                        ratings1.Add(rating);
                        ratings2.Add(item.Value.Where(x => x.KorisnikId == rating.KorisnikId).First());
                    }
                }
                double similarity = GetSimilarity(ratings1, ratings2);
                if (similarity > 0.5)
                {
                    recomendedRecepts.Add(db.Recepti.Where(x => x.Id == item.Key).FirstOrDefault());
                }
                ratings1.Clear();
                ratings2.Clear();
            }

            return recomendedRecepts;
        }

        private double GetSimilarity(List<Database.Rating> ratings1, List<Database.Rating> ratings2)
        {
            if (ratings1.Count != ratings2.Count)
            {
                return 0;
            }

            double x = 0, y1 = 0, y2 = 0;
            for (int i = 0; i < ratings1.Count; i++)
            {
                x = (int)ratings1[i].Mark * (int)ratings2[i].Mark;
                y1 = (int)ratings1[i].Mark * (int)ratings1[i].Mark;
                y2 = (int)ratings2[i].Mark * (int)ratings2[i].Mark;
            }
            y1 = Math.Sqrt(y1);
            y2 = Math.Sqrt(y2);

            double y = y1 * y2;
            if (y == 0)
                return 0;
            return x / y;
        }

        private void LoadRecepts(int receptId, int kategorijaId)
        {
            List<Database.Recept> recepts = db.Recepti.Where(x => x.Id != receptId).Where(x=>x.Public).Where(x=>x.KategorijaId == kategorijaId).ToList();
            List<Database.Rating> ratings = new List<Database.Rating>();
            foreach (Database.Recept item in recepts)
            {
                ratings = db.Ratings.Include(x => x.Korisnik).Where(x => x.ReceptId == item.Id).OrderBy(x => x.KorisnikId).ToList();
                if (ratings.Count > 0)
                    ratingsDictionary.Add(item.Id, ratings);
            }
        }
    }
}
