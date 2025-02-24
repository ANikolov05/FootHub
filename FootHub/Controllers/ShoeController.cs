using FootHub.Models;
using FootHub.Models.DataBase;
using FootHub.Models.Entitites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FootHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoeController : ControllerBase
    {
        private readonly FootHubDBContext dbContext;
        public ShoeController(FootHubDBContext dBContext)
        {
            this.dbContext = dbContext;
        }
        [HttpPost]
        public IActionResult GetAllShoes()
        {
            var allShoes = dbContext.Shoes.ToList();
            return Ok(allShoes);
        }

        [HttpPost]
        [Route("{ShoeName}")]
        public IActionResult GetShoeByName(string ShoeName)
        {
            var shoeToFind = dbContext.Shoes.Find(ShoeName);
            if (shoeToFind == null) 
            {
                return NotFound();
            }
            else 
            { 
                return Ok(shoeToFind);
            }
        }
        [HttpPost]
        public IActionResult AddShoe(AddShoeDto addShoeDto)
        {
            var shoeentity = new Shoe()
            {
                

                Brand = addShoeDto.Brand,
                ShoeName = addShoeDto.ShoeName,
                ShoePrice = addShoeDto.ShoePrice,
                Gender = addShoeDto.Gender,
                ShoeSize = addShoeDto.ShoeSize,
                ShoeColour = addShoeDto.ShoeColour,
                ImagePath = addShoeDto.ImagePath
            };

            dbContext.Shoes.Add(shoeentity);
            dbContext.SaveChanges();
            return Ok(shoeentity);
        }
        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateShoe(int id, UpdateShoeDto updateShoeDto)
        {
            var shoeToUpdate = dbContext.Shoes.Find(id);
            if (shoeToUpdate == null)
            {
                return NotFound();
            }
            shoeToUpdate.Brand = updateShoeDto.Brand;
            shoeToUpdate.ShoeName = updateShoeDto.ShoeName;
            shoeToUpdate.ShoePrice = updateShoeDto.ShoePrice;
            shoeToUpdate.Gender = updateShoeDto.Gender;
            shoeToUpdate.ShoeSize = updateShoeDto.ShoeSize;
            shoeToUpdate.ShoeColour = updateShoeDto.ShoeColour;
            shoeToUpdate.ImagePath = updateShoeDto.ImagePath;

            dbContext.SaveChanges();
            return Ok(shoeToUpdate);
            
        }
        [HttpDelete]
        public IActionResult DeleteShoe(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
           var shoeToDelete = dbContext.Shoes.Find(id);
            dbContext.Remove(shoeToDelete);
            dbContext.SaveChanges();
            return Ok();
        }
        [HttpPost]
        [Route("{gender}")]
        public IActionResult GetShoeByGender(string gender) 
        {
            List<Shoe> shoesByGender = new List<Shoe>();
            var allShoes = dbContext.Shoes.ToList() ;
            foreach (var shoe in allShoes)
            {
                if (shoe.Gender == gender)
                {
                    shoesByGender.Add(shoe);
                }
            }
            return Ok(shoesByGender);
        
        }


    }

}
