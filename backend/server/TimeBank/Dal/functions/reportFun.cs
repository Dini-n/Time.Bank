using Dal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.functions
{
    public class reportFun
    {
        // משתנה שמכיל את המסד
        static Models.TimeBankContext db = new Models.TimeBankContext();
        public static short addReport(Report rep)
        {
            try
            {
                Dal.Models.Report r = new Dal.Models.Report()
                {
                    MemberCategoryId = rep.MemberCategoryId,
                    Date = rep.Date,
                    Note = rep.Note,
                    Hour = rep.Hour,

                };
                /*,ExperienceYears = newMemCate.ExperienceYears,ForGroup=newMemCate.ForGroup
                                    ,Place= newMemCate.Place,PossibilityComeCustomerHome = newMemCate.PossibilityComeCustomerHome,*/
                rep.MemberCategory = null;
                rep.ReportsDetails = null;
                db.Reports.Add(rep);
                db.SaveChanges();
                return rep.Id;
            }
            catch (Exception e)
            {
                throw new Exception();
            }
        }
        public static void addReportDetails(List<Dal.Models.ReportsDetail> reportsDetails)
        {
            try
            {
                foreach (Dal.Models.ReportsDetail item in reportsDetails)
                {
                    item.GetterMember = null;
                    item.Report = null;
                    db.ReportsDetails.Add(item);
                }
                db.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception();
            }
        }

        public static bool checkCorrectInputRec(List<string> listRec)
        {
            foreach (string item in listRec)
            {
                if(Dal.functions.memberFun.getMemberByPhone(item) == null)
                    return false;
            }
            return true;
        }
        public static void deleteReportById(short reportID)
        {
            db.Reports.Remove(db.Reports.FirstOrDefault(r => r.Id == reportID));
        }
        //return true if is approved
        public static bool checkIsReportApproved(short reportId)
        {
            //have one that reciver not approveed
            bool isNotApproved = db.ReportsDetails.Where(o => o.ReportId == reportId).Any(l => l.ReceiverApproved == false);

            if (isNotApproved)
                return false;
            return false;
        }

        public static void updateHours(string phone, TimeSpan addHours)
        {
            //TODO - lock with semaphor the account (an array of semaphors)
            //TODO lock
            db.Members.FirstOrDefault(m => m.Phone == phone).RemainingHours += addHours;
            db.SaveChanges();
            //TODO unlock semaphor
        }
        public static int getNumOfGettersOfReportById(short reportId)
        {
            return db.ReportsDetails.Where(r => r.ReportId == reportId).ToList().Count;
        }

        public static TimeSpan getTimeOfReportById(short reportId)
        {
            return db.Reports.FirstOrDefault(r => r.Id == reportId).Hour;
        }

        //מאשר חבר בדיווח
        public static bool GetterAproveReport(string phone, short reportId)
        {
            try
            {
                Dal.Models.ReportsDetail r = db.ReportsDetails.FirstOrDefault(rd => rd.GetterMember.Phone == phone && rd.ReportId == reportId);
                if (r == null)
                    return false;
                r.ReceiverApproved = true;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                throw new Exception();
            }
        }
    }
}
