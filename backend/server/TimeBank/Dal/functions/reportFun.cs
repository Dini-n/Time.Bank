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
   //     static Models.TimeBankContext db = new Models.TimeBankContext();
        public static async Task< short> addReport(Report rep)
        {
            Models.TimeBankContext db = new Models.TimeBankContext();

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
               await db.SaveChangesAsync();
                return rep.Id;
            }
            catch (Exception e)
            {
                throw new Exception();
            }
        }
        public static async Task addReportDetails(List<Dal.Models.ReportsDetail> reportsDetails)
        {
            Models.TimeBankContext db = new Models.TimeBankContext();

            try
            {
                foreach (Dal.Models.ReportsDetail item in reportsDetails)
                {
                    item.GetterMember = null;
                    item.Report = null;
                   await db.ReportsDetails.AddAsync(item);
                }
               await db.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception();
            }
        }

        public static async Task< bool> checkCorrectInputRec(List<string> listRec)
        {
            Models.TimeBankContext db = new Models.TimeBankContext();

            foreach (string item in listRec)
            {
                if(await Dal.functions.memberFun.getMemberByPhone(item) == null)
                    return  false;
            }
            return true;
        }
        public static async Task deleteReportById(short reportID)
        {
            Models.TimeBankContext db = new Models.TimeBankContext();

            Dal.Models.Report report = await db.Reports.FirstOrDefaultAsync(r => r.Id == reportID);
            db.Reports.Remove(report);
            await db.SaveChangesAsync();
        
         }
        //return true if is approved
        public static async Task< bool>checkIsReportApproved(short reportId)
        {
            Models.TimeBankContext db = new Models.TimeBankContext();

            //have one that reciver not approveed
            bool isNotApproved =await db.ReportsDetails.Where(o => o.ReportId == reportId).AnyAsync(l => l.ReceiverApproved == false);

            if (isNotApproved)
                return false;
            return false;
        }

        public static async Task updateHours(string phone, TimeSpan addHours)
        {
            Models.TimeBankContext db = new Models.TimeBankContext();

            //TODO - lock with semaphor the account (an array of semaphors)
            //TODO lock
            Dal.Models.Member m=  await db.Members.FirstOrDefaultAsync(m => m.Phone == phone);
            m.RemainingHours += addHours;
            await db.SaveChangesAsync();
            //TODO unlock semaphor
        }
        public static async Task< int> getNumOfGettersOfReportById(short reportId)
        {
            Models.TimeBankContext db = new Models.TimeBankContext();

            List< Dal.Models.ReportsDetail> reportsDetail = await db.ReportsDetails.Where(r => r.ReportId == reportId).ToListAsync();
            return reportsDetail.Count;
        }

        public static async Task< TimeSpan> getTimeOfReportById(short reportId)
        {
            Models.TimeBankContext db = new Models.TimeBankContext();

            Dal.Models.Report report = await db.Reports.FirstOrDefaultAsync(r => r.Id == reportId);
            return report.Hour;
        }

        //מאשר חבר בדיווח
        public static async Task< bool> ApproveReceiptsInReport(string phone, short reportId)
        {
            Models.TimeBankContext db = new Models.TimeBankContext();

            try
            {
                Dal.Models.ReportsDetail r =await db.ReportsDetails.FirstOrDefaultAsync(rd => rd.GetterMember.Phone == phone && rd.ReportId == reportId);
                if (r == null)
                    return false;
                r.ReceiverApproved = true;
               await db.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                throw new Exception();
            }
        }
    }
}
