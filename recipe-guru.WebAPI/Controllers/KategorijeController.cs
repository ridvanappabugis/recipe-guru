using System;
using recipe_guru.WebAPI.Services;

namespace recipe_guru.WebAPI.Controllers
{
    public class KategorijeController : BaseController<Model.Kategorija, object>
    {
        public KategorijeController(IService<Model.Kategorija, object> service) : base(service)
        {

        }
    }
}
