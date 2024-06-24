using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Services.ProductDetailDetailServices;
using MultiShop.Catalog.Services.ProductServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailsController : ControllerBase
    {
        private readonly IProductDetailService _ProductDetailsService;

        public ProductDetailsController(IProductDetailService ProductDetailService)
        {
            _ProductDetailsService = ProductDetailService;
        }
        [HttpGet]
        public async Task<IActionResult> ProductDetailsList()
        {
            var values = await _ProductDetailsService.GettAllProductDetailAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductDetailByID(string id)
        {
            var values = _ProductDetailsService.GetByIdProductDetailAsync(id);
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProductDetails(CreateProductDetailDto createProductDetailDto)
        {
            await _ProductDetailsService.CreateProductDetailAsync(createProductDetailDto);
            return Ok("Ürün Detayı Başarıyla Eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProductDetails(string id)
        {
            await _ProductDetailsService.DeleteProductDetailAsync(id);
            return Ok("Ürün Detayı Başarıyla Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProductDetails(UpdateProductDetailDto updateProductDetailDto)
        {
            await _ProductDetailsService.UpdateProductDetailAsync(updateProductDetailDto);
            return Ok("Ürün Detayı Başarıyla Güncellendi");
        }
    }
}
