using System;
using recipe_guru.WebAPI.Services;
using recipe_guru.WebAPI.Database;
using recipe_guru.Model.Requests;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace recipe_guru.WebAPI.Services
{
    public class KnjigaRecepataService
        : BaseCRUDService<Model.KnjigaRecepata, KnjigaRecepataSearchRequest, KnjigaRecepataUpsertRequest, KnjigaRecepataUpsertRequest, Database.KnjigaRecepata>
    {
        public KnjigaRecepataService(recipeGuruContext context, IMapper mapper) : base(context, mapper)
        {

        }

        public override List<Model.KnjigaRecepata> Get(KnjigaRecepataSearchRequest search)
        {
            var query = _context.KnjigeRecepata.AsQueryable();

            if (search?.Naziv != null)
            {
                query = query.Where(x => x.Naziv.Contains(search.Naziv));
            }

            if (search?.KorisnikId != null && search?.KorisnikId != 0)
            {
                query = query.Where(x => x.KorisnikId == search.KorisnikId);
            }

            return _mapper.Map<List<Model.KnjigaRecepata>>(query.ToList());
        }
    }
}