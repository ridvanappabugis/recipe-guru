using System;
using recipe_guru.WebAPI.Controllers;
using recipe_guru.Model.Requests;
using recipe_guru.WebAPI.Services;

namespace recipe_guru.WebAPI.Controllers
{
    public class ReceptKoraciController
    : BaseCRUDController<Model.ReceptKorak, ReceptKoraciSearchRequest, ReceptKoraciUpsertRequest, ReceptKoraciUpsertRequest>
    {
        public ReceptKoraciController(ICRUDService<Model.ReceptKorak, ReceptKoraciSearchRequest, ReceptKoraciUpsertRequest, ReceptKoraciUpsertRequest> service) : base(service)
        {

        }
    }
}
