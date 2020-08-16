using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using recipe_guru.WebAPI.Database;

namespace recipe_guru.WebAPI.Services
{
    public class BaseCRUDService<TModel, TSearch, TInsert, TUpdate, TDatabase> :
        BaseService<TModel, TSearch, TDatabase>, ICRUDService<TModel, TSearch, TInsert, TUpdate> where TDatabase : class
    {
        public BaseCRUDService(recipeGuruContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public virtual TModel Delete(int Id)
        {
            var entity = _context.Set<TDatabase>().Find(Id);
            if (entity == null)
            {
                throw new ArgumentNullException();
            }
            var x = entity;
            _context.Set<TDatabase>().Remove(entity);
            _context.SaveChanges();
            return _mapper.Map<TModel>(x);
        }

        public virtual TModel Insert(TInsert request)
        {
            var entity = _mapper.Map<TDatabase>(request);

            _context.Set<TDatabase>().Add(entity);
            _context.SaveChanges();

            return _mapper.Map<TModel>(entity);
        }

        public virtual TModel Update(int id, TUpdate request)
        {
            var entity = _context.Set<TDatabase>().Find(id);
            _context.Set<TDatabase>().Attach(entity);
            _context.Set<TDatabase>().Update(entity);

            _mapper.Map(request, entity);

            _context.SaveChanges();

            return _mapper.Map<TModel>(entity);
        }
    }
}
