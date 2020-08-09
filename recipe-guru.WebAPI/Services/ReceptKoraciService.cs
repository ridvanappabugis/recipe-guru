using System;
using recipe_guru.WebAPI.Services;
using recipe_guru.WebAPI.Database;
using recipe_guru.Model.Requests;
using AutoMapper;

namespace recipe_guru.WebAPI.Services
{
    public class ReceptKoraciService
        : BaseCRUDService<Model.ReceptKorak, ReceptKoraciSearchRequest, ReceptKoraciUpsertRequest, ReceptKoraciUpsertRequest, Database.ReceptKoraci>
    {
        public ReceptKoraciService(recipeGuruContext context, IMapper mapper) : base(context, mapper)
        {

        }
    }
}
