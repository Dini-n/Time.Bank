using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.functions
{
    public class categoriesFunctions
    {
        // מחזירה את כל הקטגוריות
        public static async Task<List<Dto.dtoClasses.CategoryDto>> GetAllCategoriesBll()
        {
            List<Dto.dtoClasses.CategoryDto> l =await Bll.converters.categoryConvert.ConvertListFromMicToDto(Dal.functions.categoryFun.GetAllCategories());
            return l;
        }
        // מוסיפה קטגוריה
        public static async Task addCategory(Dto.dtoClasses.CategoryDto mnew , string fatherCatId)
        {
          await  Dal.functions.categoryFun.addCategory(await Bll.converters.categoryConvert.convertFromDtoToMicroWhithRouter(mnew,fatherCatId));

        }
        public static async Task< Dto.dtoClasses.CategoryDto> GetCategoriesByName(string name)
        {
            Dto.dtoClasses.CategoryDto l = Bll.converters.categoryConvert.convertFromMicToDto(await Dal.functions.categoryFun.GetCategoryByName(name));
            return l;
        }
    }
}
