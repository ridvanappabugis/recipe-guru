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
        List<Model.Korisnik> Get(KorisniciSearchRequest request);

        Model.Korisnik GetById(int id);

        Model.Korisnik Insert(KorisniciInsertRequest request);

        Model.Korisnik Update(int id, KorisniciInsertRequest request);

        Model.Korisnik Authenticiraj(string username, string pass);

        Model.Korisnik Delete(int Id);
    }
}
