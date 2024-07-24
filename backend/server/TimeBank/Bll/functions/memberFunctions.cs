using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.functions
{
    public static class memberFunctions
    {
        public static async Task<bool> isManager(string phone, string pass)
        {
           return await  Dal.functions.memberFun.isManager(phone, pass);
           
        }
        public static async Task<Dto.dtoClasses.MemberDto> getMemberByPhone(string name)
        {
            return Bll.memberConvert.convertFromMicToDto
                (await Dal.functions.memberFun.getMemberByPhone(name));
        }
        public static async Task<List<Dto.dtoClasses.MemberDto>> GetAllMembersBll()
        {
            return Bll.memberConvert.ConvertListFromMicToDto(await Dal.functions.memberFun.GetAllMembers());
        }
        public static async Task addMember(Dto.dtoClasses.MemberDto mnew)
        {
           await Dal.functions.memberFun.addMember( memberConvert.convertFromDtoToMicro(mnew));
        }
        public static async Task approveMember(string phone)
        {
          await  Dal.functions.memberFun.approveMember(phone);
        }
        public static async Task<Dto.dtoClasses.MemberDto> checkMemberByPhoneAndPass(string phone, string pass)
        {
            Dal.Models.Member tempMember =await Dal.functions.memberFun.checkMemberByPhoneAndPass(phone, pass);
            if (tempMember != null)
            {
            
                return Bll.memberConvert.convertFromMicToDto(tempMember);
            }
            return null;
        }
        public static async Task swichActive(string phone , bool nextStatus)
        {
          await  Dal.functions.memberFun.swichActive(phone, nextStatus);
        }
    }
}
