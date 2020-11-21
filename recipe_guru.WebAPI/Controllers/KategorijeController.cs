using System;
using recipe_guru.WebAPI.Services;
using recipe_guru.Model.Requests;

namespace recipe_guru.WebAPI.Controllers
{
    public class KategorijeController : BaseCRUDController<Model.Kategorija, KategorijeSearchRequest, KategorijeAddRequest, KategorijeAddRequest>
    {
        public KategorijeController(ICRUDService<Model.Kategorija, KategorijeSearchRequest, KategorijeAddRequest, KategorijeAddRequest> service) : base(service)
        {

        }
    }
}
