using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeBank.Controllers
{
     public class para
    {
        public string phone { get; set; }
        public string catName { get; set; }
        public Dto.dtoClasses.CategoryMemberDto newMemberCat { get; set; }

    }

    [Route("api/[controller]")]
    [ApiController]
    public class memberCategoryController : ControllerBase
    {//בפוסט שולחים רק משתנה אחד! בגט אפשר שתים בURL אבל אם אצ רוצה בפוסט-תצרי מערך
        [HttpPost("addMemberCategory")]
        public async Task<ActionResult<Dto.dtoClasses.CategoryMemberDto>> addMemberCategory
            (para PhoneAndCatName)
        {
            Dto.dtoClasses.CategoryMemberDto newMemberCat = PhoneAndCatName.newMemberCat;
            string memberPhone = PhoneAndCatName.phone;
            string categoryName = PhoneAndCatName.catName;
            try
            {
                
                  await Bll.functions.memberCategoryFunction.addMemberCategory(newMemberCat, memberPhone, categoryName);
                    return Ok(newMemberCat);
            }
            catch
            { return null; }

        }

        [HttpGet("getAllMemberCategory")]

        public async Task<ActionResult<List<Dto.dtoClasses.CatPlusMemberDto>>> getAllMemberCategory()
        {
             List<Dto.dtoClasses.CatPlusMemberDto> catPlusMembers = await Bll.functions.memberCategoryFunction.getAllCategoriesMember();
            return Ok(catPlusMembers);
        }
    
       // [HttpGet("getFilterMemberCategory")]
        [HttpPost("getFilterMemberCategory")]

        public async Task<ActionResult<List<Dto.dtoClasses.CatPlusMemberDto>>> getFilterMemberCategory(Dto.dtoClasses.CatPlusMemberDto filter)
        {
            List<Dto.dtoClasses.CatPlusMemberDto> catPlusMembers = await Bll.functions.memberCategoryFunction.GetFilteredMemberCategories(filter);
            return Ok(catPlusMembers);
        }
    }
}
