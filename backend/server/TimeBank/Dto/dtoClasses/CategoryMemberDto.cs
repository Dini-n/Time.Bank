using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.dtoClasses
{
  public  class CategoryMemberDto {

       
        public CategoryDto Category { get; set; }
        public string Place { get; set; }
        public bool? PossibilityComeCustomerHome { get; set; }
        public short? ExperienceYears { get; set; }
        public string RestrictionsDescription { get; set; }
        public bool? ForGroup { get; set; }
        public short? MinGruop { get; set; }
        public short? MaxGroup { get; set; }

        public List<ReportAndDetailDto> reports { get; set; }

    }
}
