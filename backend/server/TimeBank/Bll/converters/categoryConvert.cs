﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.converters
{
   public class categoryConvert
    {
        //המרת קטגוריה ממיקרוסופט אלינו
        public static Dto.dtoClasses.CategoryDto convertFromMicToDto( Dal.Models.Category microCategory)
        {
            if (microCategory == null)
                return null;
            Dto.dtoClasses.CategoryDto retCategory = new Dto.dtoClasses.CategoryDto();
            retCategory.name = microCategory.Name;
            retCategory.fatherCategoryId = microCategory.FatherCategoryId;
            retCategory.approved = microCategory.Approved;
            retCategory.amountPeopleOffered = microCategory.AmountPeopleOffered;
           
            return retCategory;
        }

        // (ממנו למיקרוסופט (קטגוריה
        public static Dal.Models.Category convertFromDtoToMicro(Dto.dtoClasses.CategoryDto c)
        {
            Dal.Models.Category microCategory = new Dal.Models.Category();
            microCategory.Name = c.name; 
            microCategory.FatherCategoryId = c.fatherCategoryId;
            microCategory.Approved =  c.approved;
            microCategory.AmountPeopleOffered = c.amountPeopleOffered ;
            return microCategory;
        }
        public static async Task< Dal.Models.Category> convertFromDtoToMicroWhithRouter(Dto.dtoClasses.CategoryDto c,string categoryFather)
        {
            Dal.Models.Category microCategory = new Dal.Models.Category();
            microCategory.Name = c.name;
            microCategory.FatherCategoryId = c.fatherCategoryId;
            microCategory.Approved = c.approved;
            microCategory.AmountPeopleOffered = c.amountPeopleOffered;
            Dal.Models.Category cat =await Dal.functions.categoryFun.GetCategoryByName(categoryFather);
            if (cat != null)
                microCategory.FatherCategoryId = cat.Id;
            return microCategory;
        }

        // ממיר רשימה של מיקרוסופט אלנו
        public static async  Task<List<Dto.dtoClasses.CategoryDto>> ConvertListFromMicToDto(Task< List<Dal.Models.Category>> microCategoryList)
        {
            List<Dto.dtoClasses.CategoryDto> lc = new List<Dto.dtoClasses.CategoryDto>();
            microCategoryList.Result.ForEach(m => lc.Add(convertFromMicToDto(m)));
            return lc;
        }
    }
}
