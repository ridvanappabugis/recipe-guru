using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using recipe_guru.WebAPI.Util;
using recipe_guru.Model.Requests;
using recipe_guru.WebAPI.Database;
using Microsoft.EntityFrameworkCore;
using recipeguru.WebAPI.Exceptions;

namespace recipe_guru.WebAPI.Services
{
   
    public class KorisniciService : IKorisniciService
    {
        private readonly recipeGuruContext _context;
        private readonly IMapper _mapper;
        public KorisniciService(recipeGuruContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Model.Korisnik Authenticiraj(string username, string pass)
        {
            var user = _context.Korisnici.Include(k => k.Uloga).FirstOrDefault(x => x.KorisnickoIme == username);

            if (user != null)
            {
                var newHash = PasswordUtil.GenerateHash(user.LozinkaSalt, pass);

                if(newHash == user.LozinkaHash)
                {
                    return _mapper.Map<Model.Korisnik>(user);
                }
            }
            return null;
        }

        public List<Model.Korisnik> Get(KorisniciSearchRequest request)
        {
            var query = _context.Korisnici.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request?.Ime))
            {
                query = query.Where(x => x.Ime.StartsWith(request.Ime));
            }

            if (!string.IsNullOrWhiteSpace(request?.Prezime))
            {
                query = query.Where(x => x.Prezime.StartsWith(request.Prezime));
            }

            if(request?.IsUlogeLoadingEnabled == true)
            {
                query = query.Include(x => x.Uloga);
            }

            var list = query.ToList();

            return _mapper.Map<List<Model.Korisnik>>(list);
        }

        public Model.Korisnik GetById(int id)
        {
            var entity = _context.Korisnici.Find(id);

            return _mapper.Map<Model.Korisnik>(entity);
        }

        public Model.Korisnik Insert(KorisniciInsertRequest request)
        {
            var entity = _mapper.Map<Database.Korisnici>(request);

            if (_context.Korisnici.Where(k => k.KorisnickoIme == request.KorisnickoIme).Any())
            {
                throw new UserException("Username je zauzet");
            }

            if (request.Password != request.PasswordPotvrda)
            {
                throw new Exception("Passwordi se ne slažu");
            }

            entity.LozinkaSalt = PasswordUtil.GenerateSalt();
            entity.LozinkaHash = PasswordUtil.GenerateHash(entity.LozinkaSalt, request.Password);

            _context.Korisnici.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<Model.Korisnik>(entity);
        }

        public Model.Korisnik Update(int id, KorisniciInsertRequest request)
        {
            var entity = _context.Korisnici.Find(id);
            _context.Korisnici.Attach(entity);
            _context.Korisnici.Update(entity);

            if(!string.IsNullOrWhiteSpace(request.Password))
            {
                if (request.KorisnickoIme != entity.KorisnickoIme
                        && _context.Korisnici.Where(k => k.KorisnickoIme == request.KorisnickoIme).Any())
                {
                    throw new UserException("Username je zauzet");
                }

                if (request.Password != request.PasswordPotvrda)
                {
                    throw new Exception("Passwordi se ne slažu");
                }

                entity.LozinkaSalt = PasswordUtil.GenerateSalt();
                entity.LozinkaHash = PasswordUtil.GenerateHash(entity.LozinkaSalt, request.Password);
            }

            _mapper.Map(request, entity);

            _context.SaveChanges();

            return _mapper.Map<Model.Korisnik>(entity);
        }

        public Model.Korisnik Delete(int Id)
        {
            var entity = _context.Korisnici.Find(Id);

            if (entity == null)
            {
                throw new ArgumentNullException();
            }

            var x = entity;
            _context.Korisnici.Remove(entity);
            _context.SaveChanges();

            return _mapper.Map<Model.Korisnik>(x);
        }
    }
}
