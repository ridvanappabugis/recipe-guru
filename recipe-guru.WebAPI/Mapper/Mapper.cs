using System;
using AutoMapper;

namespace recipe_guru.WebAPI.Mapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Database.Korisnici, Model.Korisnici>();
            CreateMap<Database.Korisnici, Model.Requests.KorisniciInsertRequest>().ReverseMap();
        }
    }
}
