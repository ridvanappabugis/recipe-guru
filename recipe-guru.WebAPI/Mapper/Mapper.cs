using System;
using AutoMapper;

namespace recipe_guru.WebAPI.Mapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Database.Korisnici, Model.Korisnik>();
            CreateMap<Database.Korisnici, Model.Requests.KorisniciInsertRequest>().ReverseMap();

            CreateMap<Database.Kategorije, Model.Kategorija>();

            CreateMap<Database.ImageResources, Model.ImageResource>();

            CreateMap<Database.KnjigeRecepata, Model.KnjigaRecepata>();
            CreateMap<Database.KnjigeRecepata, Model.Requests.KnjigaRecepataUpsertRequest>().ReverseMap();

            CreateMap<Database.Recepti, Model.Recept>();
            CreateMap<Database.Recepti, Model.Requests.ReceptUpsertRequest>().ReverseMap();

            CreateMap<Database.ReceptKoraci, Model.ReceptKorak>();
            CreateMap<Database.ReceptKoraci, Model.Requests.ReceptKoraciUpsertRequest>().ReverseMap();

            CreateMap<Database.Ratings, Model.Rating>();
            CreateMap<Database.Ratings, Model.Requests.RatingUpsertRequest>().ReverseMap();

        }
    }
}
