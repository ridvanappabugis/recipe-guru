using System;
using AutoMapper;
using recipe_guru.Model.Requests;
using recipe_guru.WebAPI.Database;

namespace recipe_guru.WebAPI.Services
{
    public class ImageResourceService : BaseCRUDService<Model.ImageResource, ImageResourceSearchRequest, ImageResourceUpsertRequest, ImageResourceUpsertRequest, Database.ImageResource>
    {
        public ImageResourceService(recipeGuruContext context, IMapper mapper) : base(context, mapper)
        {

        }
    }
}
