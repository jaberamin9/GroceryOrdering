using GroceryOrdering.Data;
using GroceryOrdering.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GroceryOrdering.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly GroceryOrderingDbContext dbContext;
        public ProductsController(GroceryOrderingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {
            return Ok(await dbContext.Products.Include(p => p.Images).ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(AddProductModel addProductModel)
        {
            Product product = new Product()
            {
                Id = Guid.NewGuid(),
                Title = addProductModel.Title,
                Description = addProductModel.Description,
                Price = addProductModel.Price,
                DiscountPercentage = addProductModel.DiscountPercentage,
                Rating = addProductModel.Rating,
                Stock = addProductModel.Stock,
                Brand = addProductModel.Brand,
                Category = addProductModel.Category,
                Thumbnail = addProductModel.Thumbnail,
                Images = addProductModel.Images
            };
            await dbContext.Products.AddAsync(product);
            await dbContext.SaveChangesAsync();
            return Ok(product);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] Guid id,AddProductModel productModel)
        {
            var product = await dbContext.Products.FindAsync(id);
            if(product != null)
            {
                product.Title = productModel.Title;
                product.Description = productModel.Description;
                product.Price = productModel.Price;
                product.DiscountPercentage = productModel.DiscountPercentage;
                product.Rating = productModel.Rating;
                product.Stock = productModel.Stock;
                product.Brand = productModel.Brand;
                product.Category = productModel.Category;
                product.Thumbnail = productModel.Thumbnail;
                product.Images = productModel.Images;

                await dbContext.SaveChangesAsync();
                return Ok(product);
            }
            return NotFound();
        }
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetProduct([FromRoute] Guid id)
        {
            var product = await dbContext.Products.FindAsync(id);
            if (product != null)
            {
                return Ok(product);
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] Guid id)
        {
            var product = await dbContext.Products.FindAsync(id);
            if (product != null)
            {
                dbContext.Remove(product);
                await dbContext.SaveChangesAsync();
                return Ok(product);
            }
            return NotFound();
        }

        [HttpPost]
        [Route("api/[controller]/image")]
        public async Task<IActionResult> AddImageProduct(ProductImageUI productImageUI)
        {

            ProductImagesModelcs productImages = new ProductImagesModelcs()
            {
                Url = productImageUI.Url,
                ProductId = productImageUI.ProductId
            };

            await dbContext.ProductImages.AddAsync(productImages);
            await dbContext.SaveChangesAsync();
            return Ok(productImages);
        }

        [HttpDelete]
        [Route("api/[controller]/image/{id:int}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int id)
        {
            var image = await dbContext.ProductImages.FindAsync(id);
            if (image != null)
            {
                dbContext.Remove(image);
                await dbContext.SaveChangesAsync();
                return Ok(image);
            }
            return NotFound();
        }

        [HttpPut]
        [Route("api/[controller]/image/{id:int}")]
        public async Task<IActionResult> UpdateImageProduct([FromRoute] int id, ProductImageUI productImageUI)
        {
            var image = await dbContext.ProductImages.FindAsync(id);
            if (image != null)
            {
                image.Url = productImageUI.Url;
                image.ProductId = productImageUI.ProductId;

                await dbContext.SaveChangesAsync();
                return Ok(image);
            }
            return NotFound();
        }
    }
}
