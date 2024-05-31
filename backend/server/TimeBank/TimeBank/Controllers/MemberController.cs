using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeBank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        [HttpGet("getAllMembers")]
        public ActionResult<List<Dto.dtoClasses.MemberDto>> getAllMembers()
        {
            return Ok(Bll.functions.memberFunctions.GetAllMembersBll());
        }
        //הוספת חבר חדש
        [HttpPost("addMember")]
        public ActionResult<Dto.dtoClasses.MemberDto> addMember(Dto.dtoClasses.MemberDto newMem)
        {
            try
            { 
             Bll.functions.memberFunctions.addMember(newMem);
             return Ok(newMem);
            }
            catch
            { return null; }

        }

        [HttpPut("aproveMember/{phone}")]
        public ActionResult<int> aproveMember(string phone)
        {
            try
            {
                Bll.functions.memberFunctions.approveMember(phone);
                /*פה לקרוא לפונקציות של השכבות מתחת שלוקחות את החבר שנשלח ופשוט משנות את הערך של צק לשקר*/
                return Ok(1);
            }
            catch
            { return BadRequest(0); }

        }
        //getMemberByPhone -  מחזיר את החבר בעל הטלפון הנל
        /*[HttpGet("getMemberByPhone/{phone}")]
        public ActionResult<Dto.dtoClasses.member> getMemberByPhone(string phone)  
        {
            Dto.dtoClasses.member v = Bll.functions.memberFunctions.getMemberByPhone(phone);
            return Ok(v);
        }
       */
        [HttpGet("checkMemberByPhoneAndPass/{phone}/{pass}")]
        public ActionResult<Dto.dtoClasses.MemberDto> checkMemberByPhoneAndPass(string phone,string pass)
        {
            Dto.dtoClasses.MemberDto v = Bll.functions.memberFunctions.checkMemberByPhoneAndPass(phone,pass);
            return Ok(v);
        }
        //chscks it a member is a manager by his phone and password
        [HttpGet("isManager/{phone}/{pass}")]
        public ActionResult<bool> isManager(string phone, string pass)
        {
            bool isManager = Bll.functions.memberFunctions.isManager(phone, pass);
            return Ok(isManager);
        }
        [HttpPut("swichActive/{phone}/{nextStatus}")]
        public void swichActive(string phone , bool nextStatus)
        {
            /*הולך והופך את מצב החבר*/
            Bll.functions.memberFunctions.swichActive(phone, nextStatus);
        }
    }
}
