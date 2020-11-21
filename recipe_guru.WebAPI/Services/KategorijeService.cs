using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using recipe_guru.Model.Requests;
using recipe_guru.WebAPI.Database;

namespace recipe_guru.WebAPI.Services
{
    public class KategorijeService : BaseCRUDService<Model.Kategorija, KategorijeSearchRequest, KategorijeAddRequest, KategorijeAddRequest, Database.Kategorija>
    {
        public KategorijeService(recipeGuruContext context, IMapper mapper) : base(context, mapper)
        {

        }

        public override Model.Kategorija Delete(int Id)
        {
            var entity = _context.Set<Database.Kategorija>().Find(Id);
            if (entity == null)
            {
                throw new ArgumentNullException();
            }

            foreach (var recept in _context.Set<Database.Recept>().Include(x => x.Ratings)
                .Where(x => x.KategorijaId == Id).ToList())
            {
                foreach (var rating in recept.Ratings)
                {
                    _context.Set<Database.Rating>().Remove(rating);
                }

                _context.Set<Database.Recept>().Remove(recept);

            }

            var x = entity;
            _context.Set<Database.Kategorija>().Remove(entity);
            _context.SaveChanges();
            return _mapper.Map<Model.Kategorija>(x);
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
