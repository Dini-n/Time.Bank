using Dal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.functions
{
    public class memberFun
    {   // משתנה שמכיל את המסד
     //   public static Models.TimeBankContext db = new Models.TimeBankContext();
        /*-------------------כשזה יהיה יותר יעיל נעשה דיקשנרי של גישה לפי טלפון------------*/

        // פונקציה שמחזירה את החברים מהמסד בסוג המסד
        public static async Task< List<Models.Member>> GetAllMembers()
        {
            Models.TimeBankContext db = new Models.TimeBankContext();

            db.Members.Include(m => m.MemberCategories).ToList();
            db.Reports.Include(m => m.ReportsDetails).ToList();
            db.MemberCategories.Include(m => m.Reports).ToList();
            db.MemberCategories.Include(m => m.Category).ToList();

            try
            {
                return await db.Members.ToListAsync();
            }
            catch
            {
                return null;
            }
        }
        // פונ שמקבלת משתנה מסוג המסד ומוסיפה אותו למסד
        public static async Task addMember(Dal.Models.Member newm)
        {
            Models.TimeBankContext db = new Models.TimeBankContext();

            try
            {
  /*              db.Members.Include(m => m.MemberCategories).ToList();
                db.Reports.Include(m => m.ReportsDetails).ToList();
                db.MemberCategories.Include(m => m.Reports).ToList();
                db.MemberCategories.Include(m => m.Category).ToList();*/
                
                db.Members.Add(newm);
                newm.MemberCategories = null;
                newm.ReportsDetails = null;
                newm.WaitingLists = null;
               await db.SaveChangesAsync();

                return;

            }
            catch
            {
                return;
            }
        }
        // פונ שמעדכנת חבר להיות מאושר
        public static async Task approveMember(string phone)
        {
            Models.TimeBankContext db = new Models.TimeBankContext();

            try
            {
                db.Members.FirstOrDefault(m => m.Phone == phone).ToCheck = false;
              await  db.SaveChangesAsync();
                return;
            }
            catch
            {
                return;
            }
            // db.Members.
        }
        //getMemberByPhone
        public static async Task< Dal.Models.Member> getMemberByPhone(string phone)
        {
            Models.TimeBankContext db = new Models.TimeBankContext();

            try
            {
                db.Members.Include(m => m.MemberCategories).ToList();
                db.Reports.Include(m => m.ReportsDetails).ToList();
                db.MemberCategories.Include(m => m.Reports).ToList();
                db.MemberCategories.Include(m => m.Category).ToList();

                Dal.Models.Member mm = db.Members.FirstOrDefault(m => m.Phone == phone);
                return await db.Members.FirstOrDefaultAsync(m => m.Phone == phone);
            }
            catch
            {
                throw new Exception();
            }
        }
        public static async Task< bool> isManager(string phone, string pass)
        {
            Models.TimeBankContext db = new Models.TimeBankContext();

            Dal.Models.Member tempMem =await db.Members.FirstOrDefaultAsync(m => m.Phone == phone);
            if (tempMem == null || tempMem.IsManager != true)
                return false;
            return true;
        }
        public static async Task< Models.Member> checkMemberByPhoneAndPass(string phone, string pass)
        {
            Models.TimeBankContext db = new Models.TimeBankContext();

            try
            {
                // שם בחבר את כל המאפיינים כלומר מחזיר חבר עם קטגוריות דיווחים וכו
                db.Members.Include(m => m.MemberCategories).ToList();
                db.Reports.Include(m => m.ReportsDetails).ToList();
                db.MemberCategories.Include(m => m.Reports).ToList();
                db.MemberCategories.Include(m => m.Category).ToList();
                Models.Member tempMember = await db.Members.FirstOrDefaultAsync(m => m.Phone.Equals(phone) && m.Password.Equals(pass));

                if (tempMember.RemainingHours.TotalHours < -10)
                    return null;
                if (tempMember.ToCheck == false)
                    return tempMember;
                return null;
               
            }
            catch
            {
                throw new Exception();
            }
        }
        public static async Task swichActive(string phone, bool nextStatus)
        {
            Models.TimeBankContext db = new Models.TimeBankContext();

            try
            {
                db.Members.FirstOrDefault(m => m.Phone == phone).Active = nextStatus;
               await db.SaveChangesAsync();
                return;
            }
            catch
            {
                return;
            }
        }

    }
}
