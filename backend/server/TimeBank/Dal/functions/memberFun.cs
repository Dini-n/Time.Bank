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
        public static Models.TimeBankContext db = new Models.TimeBankContext();
        /*-------------------כשזה יהיה יותר יעיל נעשה דיקשנרי של גישה לפי טלפון------------*/

        // פונקציה שמחזירה את החברים מהמסד בסוג המסד
        public static List<Models.Member> GetAllMembers()
        {
            db.Members.Include(m => m.MemberCategories).ToList();
            db.Reports.Include(m => m.ReportsDetails).ToList();
            db.MemberCategories.Include(m => m.Reports).ToList();
            db.MemberCategories.Include(m => m.Category).ToList();

            try
            {
                return db.Members.ToList();
            }
            catch
            {
                return null;
            }
        }
        // פונ שמקבלת משתנה מסוג המסד ומוסיפה אותו למסד
        public static void addMember(Dal.Models.Member newm)
        {
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
                db.SaveChanges();

                return;

            }
            catch
            {
                return;
            }
        }
        // פונ שמעדכנת חבר להיות מאושר
        public static void approveMember(string phone)
        {
            try
            {
                db.Members.FirstOrDefault(m => m.Phone == phone).ToCheck = false;
                db.SaveChanges();
                return;
            }
            catch
            {
                return;
            }
            // db.Members.
        }
        //getMemberByPhone
        public static Dal.Models.Member getMemberByPhone(string phone)
        {
            try
            {
                db.Members.Include(m => m.MemberCategories).ToList();
                db.Reports.Include(m => m.ReportsDetails).ToList();
                db.MemberCategories.Include(m => m.Reports).ToList();
                db.MemberCategories.Include(m => m.Category).ToList();

                Dal.Models.Member mm = db.Members.FirstOrDefault(m => m.Phone == phone);
                return db.Members.FirstOrDefault(m => m.Phone == phone);
            }
            catch
            {
                throw new Exception();
            }
        }
        public static bool isManager(string phone, string pass)
        {
            Dal.Models.Member tempMem = db.Members.FirstOrDefault(m => m.Phone == phone);
            if (tempMem == null || tempMem.IsManager != true)
                return false;
            return true;
        }
        public static Models.Member checkMemberByPhoneAndPass(string phone, string pass)
        {
            try
            {
                // שם בחבר את כל המאפיינים כלומר מחזיר חבר עם קטגוריות דיווחים וכו
                db.Members.Include(m => m.MemberCategories).ToList();
                db.Reports.Include(m => m.ReportsDetails).ToList();
                db.MemberCategories.Include(m => m.Reports).ToList();
                db.MemberCategories.Include(m => m.Category).ToList();
                Models.Member tempMember = db.Members.FirstOrDefault(m => m.Phone == phone && m.Password == pass);
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
        public static void swichActive(string phone, bool nextStatus)
        {
            try
            {
                db.Members.FirstOrDefault(m => m.Phone == phone).Active = nextStatus;
                db.SaveChanges();
                return;
            }
            catch
            {
                return;
            }
        }

    }
}
