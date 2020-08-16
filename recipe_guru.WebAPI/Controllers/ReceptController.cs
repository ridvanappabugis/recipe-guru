using System;
using recipe_guru.WebAPI.Controllers;
using recipe_guru.Model.Requests;
using recipe_guru.WebAPI.Services;

namespace recipe_guru.WebAPI.Controllers
{
    public class ReceptController
    : BaseCRUDController<Model.Recept, ReceptSearchRequest, ReceptUpsertRequest, ReceptUpsertRequest>
    {
        public ReceptController(ICRUDService<Model.Recept, ReceptSearchRequest, ReceptUpsertRequest, ReceptUpsertRequest> service) : base(service)
        {

        }
    }
}
