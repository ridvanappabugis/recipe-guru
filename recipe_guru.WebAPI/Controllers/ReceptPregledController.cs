using System;
using recipe_guru.Model.Requests;
using recipe_guru.WebAPI.Services;

namespace recipe_guru.WebAPI.Controllers
{
    public class ReceptPregledController
    : BaseCRUDController<Model.ReceptPregled, ReceptPregledSearchRequest, ReceptPregledUpsertRequest, ReceptPregledUpsertRequest>
    {
        public ReceptPregledController(ICRUDService<Model.ReceptPregled, ReceptPregledSearchRequest, ReceptPregledUpsertRequest, ReceptPregledUpsertRequest> service) : base(service)
        {

        }
    }
}
