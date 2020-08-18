using System;
using recipe_guru.WebAPI.Services;
using recipe_guru.Model.Requests;

namespace recipe_guru.WebAPI.Controllers
{
    public class ImageResourceController : BaseCRUDController<Model.ImageResource, ImageResourceSearchRequest, ImageResourceUpsertRequest, ImageResourceUpsertRequest>
    {
        public ImageResourceController(ICRUDService<Model.ImageResource, ImageResourceSearchRequest, ImageResourceUpsertRequest, ImageResourceUpsertRequest> service) : base(service)
        {

        }
    }
}
