using Bll.converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.functions
{
    public class memberCategoryFunction
    {
        public static async Task addMemberCategory(Dto.dtoClasses.CategoryMemberDto mcnew, string phoneOfMember,string categoryName)
        {
           await Dal.functions.categoryMemberFun.addMemberCategory( await Bll.converters.categoryMemberConvert.
                convertFromDtoToMicroWhithRouter(mcnew, phoneOfMember,categoryName));

        }
        public static  async Task< List<Dto.dtoClasses.CatPlusMemberDto>> getAllCategoriesMember()
        {
             List<Dal.Models.MemberCategory> dDal =await Dal.functions.categoryMemberFun.getAllCategoriesMember();
             List<Dto.dtoClasses.CatPlusMemberDto> d = new List<Dto.dtoClasses.CatPlusMemberDto>();
            foreach (var item in dDal)
            {
                d.Add(catPlusMemberConvert.convertFromMicToDto(item));
            }
            return d;
        }

        public static async Task< List<Dto.dtoClasses.CatPlusMemberDto>> GetFilteredMemberCategories(Dto.dtoClasses.CatPlusMemberDto filter)
        {
          List<Dal.Models.MemberCategory> MC =await Dal.functions.categoryMemberFun.GetFilteredMemberCategories( filter.memGiverName, filter.memPhone,  filter.memEmail,filter.memAddress,filter.memGender,
            filter.Category.name,filter.Place,filter.PossibilityComeCustomerHome, filter.ExperienceYears, filter.RestrictionsDescription, filter.ForGroup, filter.MinGruop, filter.MaxGroup);
             List<Dto.dtoClasses.CatPlusMemberDto> d = new List<Dto.dtoClasses.CatPlusMemberDto>();
            foreach (var item in MC)
            {
                d.Add( catPlusMemberConvert.convertFromMicToDto(item));
            }
            return d;
        }
    }
}
