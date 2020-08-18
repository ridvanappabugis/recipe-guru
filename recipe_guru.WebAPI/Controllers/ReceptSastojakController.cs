using System;
using recipe_guru.Model.Requests;
using recipe_guru.WebAPI.Services;

namespace recipe_guru.WebAPI.Controllers
{
    public class ReceptSastojakController
    : BaseCRUDController<Model.ReceptSastojak, ReceptSastojakSearchRequest, ReceptSastojakUpsertRequest, ReceptSastojakUpsertRequest>
    {
        public ReceptSastojakController(ICRUDService<Model.ReceptSastojak, ReceptSastojakSearchRequest, ReceptSastojakUpsertRequest, ReceptSastojakUpsertRequest> service) : base(service)
        {

        }
    }
}
