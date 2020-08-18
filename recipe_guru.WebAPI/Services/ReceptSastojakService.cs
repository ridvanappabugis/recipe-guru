using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using recipe_guru.Model.Requests;
using recipe_guru.WebAPI.Database;

namespace recipe_guru.WebAPI.Services
{
    public class ReceptSastojakService
        : BaseCRUDService<Model.ReceptSastojak, ReceptSastojakSearchRequest, ReceptSastojakUpsertRequest, ReceptSastojakUpsertRequest, Database.ReceptSastojak>
    {
        public ReceptSastojakService(recipeGuruContext context, IMapper mapper) : base(context, mapper)
        {

        }

        public override List<Model.ReceptSastojak> Get(ReceptSastojakSearchRequest search)
        {
            var query = _context.ReceptSastojci.AsQueryable();

            query = query.Where(x => x.ReceptId == search.ReceptId);

            return _mapper.Map<List<Model.ReceptSastojak>>(query.ToList());
        }
    }
}
