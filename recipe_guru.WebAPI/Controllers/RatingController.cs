using System;
using recipe_guru.WebAPI.Controllers;
using recipe_guru.Model.Requests;
using recipe_guru.WebAPI.Services;

namespace recipe_guru.WebAPI.Controllers
{
    public class RatingController
    : BaseCRUDController<Model.Rating, RatingSearchRequest, RatingUpsertRequest, RatingUpsertRequest>
    {
        public RatingController(ICRUDService<Model.Rating, RatingSearchRequest, RatingUpsertRequest, RatingUpsertRequest> service) : base(service)
        {

        }
    }
}
