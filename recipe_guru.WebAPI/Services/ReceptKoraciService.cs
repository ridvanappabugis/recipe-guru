using System;
using recipe_guru.WebAPI.Services;
using recipe_guru.WebAPI.Database;
using recipe_guru.Model.Requests;
using AutoMapper;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace recipe_guru.WebAPI.Services
{
    public class ReceptKoraciService
        : BaseCRUDService<Model.ReceptKorak, ReceptKoraciSearchRequest, ReceptKoraciUpsertRequest, ReceptKoraciUpsertRequest, Database.ReceptKorak>
    {
        public ReceptKoraciService(recipeGuruContext context, IMapper mapper) : base(context, mapper)
        {

        }

        public override List<Model.ReceptKorak> Get(ReceptKoraciSearchRequest search)
        {
            var query = _context.ReceptKoraci.AsQueryable();

            query = query.Where(x => x.ReceptId == search.ReceptId);
            
            return _mapper.Map<List<Model.ReceptKorak>>(query.ToList());
        }
    }
}
