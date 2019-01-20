using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnderstandigMVC.Entities;
using UnderstandigMVC.Models;

namespace UnderstandigMVC.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IUnderstandingMVCRepo _repo;
        private readonly IMapper _mapper;

        public ProductController(IUnderstandingMVCRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get(bool inOrder = true)
        {
            var results = _repo.GetAllProducts(inOrder);
            //Bruger mapper til at Mappe Product til ProductModel, Vi speceficere i denne at det skal være
            //IEnumerable da det er en collection
            //Mapper entities til Model
            return Ok(_mapper.Map <IEnumerable <Product>, IEnumerable <ProductModel> > (results));
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var result = _repo.GetProductById(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<Product, ProductModel>(result));
        }

        [HttpPost]
        public IActionResult Post([FromBody] ProductModel model)
        {
            if (ModelState.IsValid)
            {
                //mapper Model til entites
                var newProduct = _mapper.Map<ProductModel, Product>(model); 

                  //Før automapper
                  //var newProduct = new Product()
                  //{
                  //    Artist = model.Artist,
                  //    ArtistId = model.ArtistId,
                  //    Title = model.Title,
                  //    Category = model.Category,
                  //    ArtistBirth = model.ArtistBirth,
                  //    ArtistDeath = model.ArtistDeath
                  //};

                  _repo.AddEntity(newProduct);
                if (_repo.SaveAll())
                {

                    var vm = _mapper.Map<Product, ProductModel>(newProduct);


                    //Før automapper
                    //var vm = new ProductModel()
                    //{
                    //    ProductId = newProduct.Id,
                    //    Artist = newProduct.Artist,
                    //    ArtistId = newProduct.ArtistId,
                    //    Title = newProduct.Title,
                    //    Category = newProduct.Category,
                    //    ArtistBirth = newProduct.ArtistBirth,
                    //    ArtistDeath = newProduct.ArtistDeath
                    //};

                    return Created($"/api/Product/{newProduct.Id}", newProduct);
                }

            }

            return BadRequest();
        }
    }

  
}
