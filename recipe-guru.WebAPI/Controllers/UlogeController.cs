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

    public class UlogeController : BaseController<Model.Uloge, object>
    {
        public UlogeController(IService<Uloge, object> service) : base(service)
        {
        }
    }
}