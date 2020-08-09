using System;
using recipe_guru.WebAPI.Controllers;
using recipe_guru.Model.Requests;
using recipe_guru.WebAPI.Services;

namespace recipe_guru.WebAPI.Controllers
{
    public class KnjigaRecepataController
    : BaseCRUDController<Model.KnjigaRecepata, KnjigaRecepataSearchRequest, KnjigaRecepataUpsertRequest, KnjigaRecepataUpsertRequest>
    {
        public KnjigaRecepataController(ICRUDService<Model.KnjigaRecepata, KnjigaRecepataSearchRequest, KnjigaRecepataUpsertRequest, KnjigaRecepataUpsertRequest> service) : base(service)
        {

        }
    }
}
