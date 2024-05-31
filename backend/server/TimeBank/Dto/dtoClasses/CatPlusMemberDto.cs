using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.dtoClasses
{
    public class CatPlusMemberDto
    {
        
        public CatPlusMemberDto()
        {
            Category = new CategoryDto();
        }
     //-----------------פרטי נותן הפעולה-----------
        public string memGiverName { get; set; }
        public string memPhone { get; set; }
        public string memEmail { get; set; }
        public string memAddress { get; set; }
        public bool? memGender { get; set; }

        //---------------- פרטי קטגורית הפעולה של הנותן-----------
        public CategoryDto Category { get; set; }
        //---------------המשך תיאור הקטגוריה פר חבר
        public string Place { get; set; }
        public bool? PossibilityComeCustomerHome { get; set; }
        public short? ExperienceYears { get; set; }
        public string RestrictionsDescription { get; set; }
        public bool? ForGroup { get; set; }
        public short? MinGruop { get; set; }
        public short? MaxGroup { get; set; }
    }
}
