using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.functions
{
   public class memberFunctions
    {
        public static List<Dto.dtoClasses.member> GetAllMembersBll()
        {
           return  Bll.converters.memberConvert.ConvertListFromMicToDto(Dal.functions.memberFun.GetAllMembers());
        }
        public static void addMember(Dto.dtoClasses.member mnew)
        {
            Dal.functions.memberFun.addMember(converters.memberConvert.convertFromDtoToMicro(mnew));
        }
        public static void approveMember(string phone)
        {
            Dal.functions.memberFun.approveMember(phone);
        }
        public static Dto.dtoClasses.member getMmberByPhone(string phone)
        {
            return Bll.converters.memberConvert.convertFromMicToDto(Dal.functions.memberFun.getMmberByPhone(phone));
        }
    }
}
