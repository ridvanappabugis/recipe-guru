using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using recipe_guru.Model.Requests;
using recipe_guru.WebAPI.Database;

namespace recipe_guru.WebAPI.Services
{
    public class KategorijeService : BaseCRUDService<Model.Kategorija, KategorijeSearchRequest, KategorijeAddRequest, KategorijeAddRequest, Database.Kategorija>
    {
        public KategorijeService(recipeGuruContext context, IMapper mapper) : base(context, mapper)
        {

        }

        public override List<Model.Kategorija> Get(KategorijeSearchRequest search)
        {
            var query = _context.Kategorije.AsQueryable();

            if (search?.Naziv != null)
            {
                query = query.Where(x => x.Naziv.Contains(search.Naziv));
            }

            if (search?.Id != null && search?.Id != 0)
            {
                query = query.Where(x => x.Id == search.Id);
            }


            return _mapper.Map<List<Model.Kategorija>>(query.ToList());
        }
    }
}
