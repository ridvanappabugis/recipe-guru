using recipe_guru.Model.Requests;
using recipe_guru.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace recipe_guru.WebAPI.Services
{
    public interface IKorisniciService
    {
        List<Model.Korisnici> Get(KorisniciSearchRequest request);

        Model.Korisnici GetById(int id);

        Model.Korisnici Insert(KorisniciInsertRequest request);

        Model.Korisnici Update(int id, KorisniciInsertRequest request);

        Model.Korisnici Authenticiraj(string username, string pass);
    }
}
