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
        static Models.TimeBankContext db = new Models.TimeBankContext();
       /*-------------------כשזה יהיה יותר יעיל נעשה דיקשנרי של גישה לפי טלפון------------*/

        // פונקציה שמחזירה את החברים מהמסד בסוג המסד
        public static List<Models.Member> GetAllMembers()
        {
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
                db.Members.Add(newm);
                
                db.SaveChanges();

                return;

            }
            catch
            {
                return;
            }
        }
        public static Dal.Models.Member getMmberByPhone(string phone)
        {
            try
            {
                Dal.Models.Member m = db.Members.FirstOrDefault(m => m.Phone == phone);
                return m;
             }
            catch
            {
                throw new Exception();
            }
        }
        // פונ שמעדכנת חבר להיות מאושר
        public static void approveMember(string phone)
        {
            try
            {

                db.Members.FirstOrDefault(m => m.Phone == phone).ToCheck = false;

                // Models.TimeBankContext.Beleges.Add(kopieren_SQL).
                db.SaveChanges();
                return;
            }
            catch
            {
                return;
            }
            // db.Members.
        }
    }
}
