using System;
using recipe_guru.WebAPI.Services;
using recipe_guru.WebAPI.Database;
using recipe_guru.Model.Requests;
using AutoMapper;

namespace recipe_guru.WebAPI.Services
{
    public class ReceptService
        : BaseCRUDService<Model.Recept, ReceptSearchRequest, ReceptUpsertRequest, ReceptUpsertRequest, Database.Recepti>
    {
        public ReceptService(recipeGuruContext context, IMapper mapper) : base(context, mapper)
        {

        }
    }
}
