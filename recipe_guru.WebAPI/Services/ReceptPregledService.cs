using System;
using AutoMapper;
using recipe_guru.Model.Requests;
using recipe_guru.WebAPI.Database;

namespace recipe_guru.WebAPI.Services
{
    public class ReceptPregledService
        : BaseCRUDService<Model.ReceptPregled, ReceptPregledSearchRequest, ReceptPregledUpsertRequest, ReceptPregledUpsertRequest, Database.ReceptPregled>
    {
        public ReceptPregledService(recipeGuruContext context, IMapper mapper) : base(context, mapper)
        {

        }
    }
}
