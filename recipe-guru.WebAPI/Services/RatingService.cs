using System;
using recipe_guru.WebAPI.Services;
using recipe_guru.WebAPI.Database;
using recipe_guru.Model.Requests;
using AutoMapper;

namespace recipe_guru.WebAPI.Services
{
    public class RatingService
        : BaseCRUDService<Model.Rating, RatingSearchRequest, RatingUpsertRequest, RatingUpsertRequest, Database.Rating>
    {
        public RatingService(recipeGuruContext context, IMapper mapper) : base(context, mapper)
        {

        }
    }
}
