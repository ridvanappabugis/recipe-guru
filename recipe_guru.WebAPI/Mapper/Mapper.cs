using System;
using AutoMapper;

namespace recipe_guru.WebAPI.Mapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Database.Korisnik, Model.Korisnik>();
            CreateMap<Database.Korisnik, Model.Requests.KorisniciInsertRequest>().ReverseMap();

            CreateMap<Database.Kategorija, Model.Kategorija>();

            CreateMap<Database.ImageResource, Model.ImageResource>();

            CreateMap<Database.KnjigaRecepata, Model.KnjigaRecepata>();
            CreateMap<Database.KnjigaRecepata, Model.Requests.KnjigaRecepataUpsertRequest>().ReverseMap();

            CreateMap<Database.Recept, Model.Recept>();
            CreateMap<Database.Recept, Model.Requests.ReceptUpsertRequest>().ReverseMap();

            CreateMap<Database.ReceptKorak, Model.ReceptKorak>();
            CreateMap<Database.ReceptKorak, Model.Requests.ReceptKoraciUpsertRequest>().ReverseMap();

            CreateMap<Database.ReceptSastojak, Model.ReceptSastojak>();
            CreateMap<Database.ReceptSastojak, Model.Requests.ReceptSastojakUpsertRequest>().ReverseMap();

            CreateMap<Database.Rating, Model.Rating>();
            CreateMap<Database.Rating, Model.Requests.RatingUpsertRequest>().ReverseMap();

            CreateMap<Database.Uloga, Model.Uloga>();

        }
    }
}
