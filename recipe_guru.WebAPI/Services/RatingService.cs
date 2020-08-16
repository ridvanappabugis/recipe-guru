using System;
using recipe_guru.WebAPI.Services;
using recipe_guru.WebAPI.Database;
using recipe_guru.Model.Requests;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace recipe_guru.WebAPI.Services
{
    public class RatingService
        : BaseCRUDService<Model.Rating, RatingSearchRequest, RatingUpsertRequest, RatingUpsertRequest, Database.Rating>
    {
        public RatingService(recipeGuruContext context, IMapper mapper) : base(context, mapper)
        {

        }

        public override List<Model.Rating> Get(RatingSearchRequest search)
        {
            var query = _context.Ratings.AsQueryable();

            if (search?.ReceptId != null && search?.ReceptId != 0)
            {
                query = query.Where(x => x.ReceptId == search.ReceptId);
            }

            if (search?.Mark != null)
            {
                query = query.Where(x => x.Mark.Equals(search.Mark));
            }

            if (search?.KorisnikId != null && search?.KorisnikId != 0)
            {
                query = query.Where(x => x.KorisnikId == search.KorisnikId);
            }

            return _mapper.Map<List<Model.Rating>>(query.ToList());
        }
    }
}
