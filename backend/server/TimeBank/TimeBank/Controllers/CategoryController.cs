using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


//DBNull.members.include(categories)
   
    //.toList()
namespace TimeBank.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpGet("getAllCategories")]
        public async Task<ActionResult<List<Dto.dtoClasses.CategoryDto>>> getAllCategories()
        {
            List<Dto.dtoClasses.CategoryDto> l =await Bll.functions.categoriesFunctions.GetAllCategoriesBll();
            return Ok(l);
        }
        [HttpPost("addCategory")]
        public async  Task<ActionResult<Dto.dtoClasses.CategoryDto>> addCategory(Dto.dtoClasses.CategoryDto newCat ,string fatherName)
        {
            try
            {
               await Bll.functions.categoriesFunctions.addCategory(newCat , fatherName);
                return Ok(newCat);
            }
            catch
            { return null; }

        }
    }
}
