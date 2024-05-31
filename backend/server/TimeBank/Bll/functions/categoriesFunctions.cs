﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.functions
{
    public class categoriesFunctions
    {
        // מחזירה את כל הקטגוריות
        public static List<Dto.dtoClasses.CategoryDto> GetAllCategoriesBll()
        {
            List<Dto.dtoClasses.CategoryDto> l = Bll.converters.categoryConvert.ConvertListFromMicToDto(Dal.functions.categoryFun.GetAllCategories());
            return l;
        }
        // מוסיפה קטגוריה
        public static void addCategory(Dto.dtoClasses.CategoryDto mnew , string fatherCatId)
        {
            Dal.functions.categoryFun.addCategory(Bll.converters.categoryConvert.convertFromDtoToMicroWhithRouter(mnew,fatherCatId));

        }
        public static Dto.dtoClasses.CategoryDto GetCategoriesByName(string name)
        {
            Dto.dtoClasses.CategoryDto l = Bll.converters.categoryConvert.convertFromMicToDto(Dal.functions.categoryFun.GetCategoryByName(name));
            return l;
        }
    }
}
