using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using recipe_guru.Model.Requests;
using recipe_guru.WebAPI.Services;

namespace recipe_guru.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecommendController : ControllerBase
    {
        public IRecommenderService _service { get; set; }

        public RecommendController(IRecommenderService service)
        {
            _service = service;
        }

        [HttpGet]
        public List<Model.Recept> RecommendProduct([FromQuery] RecommendSearchRequest request)
        {
            return _service.RecommendProduct(request.ReceptId, request.KategorijaId);
        }
    }
}
