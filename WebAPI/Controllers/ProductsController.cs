using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //loosely couples-gevşek bağlılık var 
        //naming convention
        //IoC container: inversion of control
        IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var response = _productService.GetAll();
            if (response.Success==true)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var response = _productService.Add(product);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var response = _productService.GetById(id);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        //güncelleme için httpput ama sektörde genelde silme ve güncelleme için post kullanılıyor 
    }
}
