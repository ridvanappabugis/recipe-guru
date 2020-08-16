using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using recipe_guru.WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace recipe_guru.WebAPI.Controllers
{
    public class BaseCRUDController<T, TSearch, TInsert, TUpdate> : BaseController<T, TSearch>
    {
        private readonly ICRUDService<T, TSearch, TInsert, TUpdate> _service = null;
        public BaseCRUDController(ICRUDService<T, TSearch, TInsert, TUpdate> service) : base(service)
        {
            _service = service;
        }

        [HttpPost]
        public T Insert(TInsert request)
        {
            return _service.Insert(request);
        }

        [HttpPut("{id}")]
        public T Update(int id, [FromBody]TUpdate request)
        {
            return _service.Update(id, request);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{Id}")]
        public T Delete(int Id)
        {
            return _service.Delete(Id);
        }
    }
}