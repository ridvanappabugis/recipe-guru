using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using recipe_guru.Model;
using recipe_guru.WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace recipe_guru.WebAPI.Controllers
{

    public class UlogeController : BaseController<Model.Uloga, object>
    {
        public UlogeController(IService<Uloga, object> service) : base(service)
        {
        }
    }
}