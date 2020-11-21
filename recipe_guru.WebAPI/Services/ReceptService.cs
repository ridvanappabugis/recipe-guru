using System;
using recipe_guru.WebAPI.Services;
using recipe_guru.WebAPI.Database;
using recipe_guru.Model.Requests;
using AutoMapper;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections;

namespace recipe_guru.WebAPI.Services
{
    public class ReceptService
        : BaseCRUDService<Model.Recept, ReceptSearchRequest, ReceptUpsertRequest, ReceptUpsertRequest, Database.Recept>
    {

        Dictionary<RatingMark, int> ratingMap = new Dictionary<RatingMark, int>{
            { RatingMark.ONE_STAR, 1 },
            { RatingMark.TWO_STAR, 2 },
            { RatingMark.THREE_STAR, 3 },
            { RatingMark.FOUR_STAR, 4 },
            { RatingMark.FIVE_STAR, 5 }
        };

        public ReceptService(recipeGuruContext context, IMapper mapper) : base(context, mapper)
        {

        }

        public override Model.Recept Delete(int Id)
        {
            var entity = _context.Set<Database.Recept>().Include(x => x.Ratings).Where(x=> x.Id == Id).First();
            if (entity == null)
            {
                throw new ArgumentNullException();
            }

            foreach (var rating in entity.Ratings)
            {
                _context.Set<Database.Rating>().Remove(rating);
            }

            var x = entity;
            _context.Set<Database.Recept>().Remove(entity);
            _context.SaveChanges();
            return _mapper.Map<Model.Recept>(x);
        }


        public override List<Model.Recept> Get(ReceptSearchRequest search)
        {
            var query = _context.Recepti
                .Include(x => x.Ratings)
                .Include(x => x.Kategorija)
                .AsQueryable();

            if (search?.DuzinaPripreme != null && search?.DuzinaPripreme != 0)
            {
                query = query.Where(x => x.DuzinaPripreme <= search.DuzinaPripreme);
            }

            if (search?.KnjigaRecepataId != null && search?.KnjigaRecepataId != 0)
            {
                query = query.Where(x => x.KnjigaRecepataId == search.KnjigaRecepataId);
            }

            if (search?.Naziv != null)
            {
                query = query.Where(x => x.Naziv.Contains(search.Naziv));
            }

            if (search?.AverageRating != null)
            {
                query = query.Where(x => (int)x.Ratings.Average(r => (int)r.Mark) == (int)search.AverageRating);
            }

            if (search?.KategorijaId != null && search?.KategorijaId != 0)
            {
                query = query.Where(x => search.KategorijaId == x.KategorijaId);
            }

            return _mapper.Map<List<Model.Recept>>(query.ToList());
        }
    }
}
