using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace webapi_eval.Controllers
{
    public class FoodsController : ApiController
    {
        private readonly IFoodRepository _repo;

        public FoodsController(IFoodRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Food> Get()
        {
            return _repo.GetAll();
        }
    }

    public class Food
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public IEnumerable<string> Measure { get; set; }
    }
}
