using System;
using recipe_guru.WebAPI.Services;
using recipe_guru.WebAPI.Database;
using recipe_guru.Model.Requests;
using AutoMapper;

namespace recipe_guru.WebAPI.Services
{
    public class KnjigaRecepataService
        : BaseCRUDService<Model.KnjigaRecepata, KnjigaRecepataSearchRequest, KnjigaRecepataUpsertRequest, KnjigaRecepataUpsertRequest, Database.KnjigeRecepata>
    {
        public KnjigaRecepataService(recipeGuruContext context, IMapper mapper) : base(context, mapper)
        {

        }
    }
}