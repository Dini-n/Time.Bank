using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.functions
{
    public static class memberFunctions
    {
        public static bool isManager(string phone, string pass)
        {
           return  Dal.functions.memberFun.isManager(phone, pass);
           
        }
        public static Dto.dtoClasses.MemberDto getMemberByPhone(string name)
        {
            return Bll.memberConvert.convertFromMicToDto
                (Dal.functions.memberFun.getMemberByPhone(name));
        }
        public static List<Dto.dtoClasses.MemberDto> GetAllMembersBll()
        {
            return Bll.memberConvert.ConvertListFromMicToDto(Dal.functions.memberFun.GetAllMembers());
        }
        public static void addMember(Dto.dtoClasses.MemberDto mnew)
        {
            Dal.functions.memberFun.addMember(memberConvert.convertFromDtoToMicro(mnew));
        }
        public static void approveMember(string phone)
        {
            Dal.functions.memberFun.approveMember(phone);
        }
        public static Dto.dtoClasses.MemberDto checkMemberByPhoneAndPass(string phone, string pass)
        {
            Dal.Models.Member tempMember = Dal.functions.memberFun.checkMemberByPhoneAndPass(phone, pass);
            if (tempMember != null)
            {
            
                return Bll.memberConvert.convertFromMicToDto(tempMember);
            }
            return null;
        }
        public static void swichActive(string phone , bool nextStatus)
        {
            Dal.functions.memberFun.swichActive(phone, nextStatus);
        }
    }
}
