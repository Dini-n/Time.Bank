using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.functions
{
    public  class reportFunction
    {
        public static async Task< bool> addReport(Dto.dtoClasses.ReportDto rep)
        {
            //TODO
            //1. add report
            //2. add report details
           
            Dal.Models.Report tempReport =await Bll.converters.reportConvert.convertFromDtoToMicro(rep);
            //if there is no member with this phone
            if (tempReport == null)
                return false;
            //if there is not correct phone
            if (! await Dal.functions.reportFun.checkCorrectInputRec(rep.getterMembers.Select(p => p.phone).ToList()))
                return false;
            short reportID =await Dal.functions.reportFun.addReport(tempReport);
            List<Dal.Models.ReportsDetail> reportsDetails = await Bll.converters.reportConvert.convertReceiversListFromDtoToMicro(rep.getterMembers, reportID);
            /////////////////////////
            if (reportsDetails == null)
            {
                return false;
                //delete what we added
                //לבדוק קודם תקינות אולי של כל הטלפונים ואז להכניס במקום להכניס ולמחוק
                //Dal.functions.reportFun.deleteReportById(reportID);
            }
            ///////////////////////////  
           await Dal.functions.reportFun.addReportDetails(reportsDetails);
            return true;
        }

        public static async Task< bool> checkIsReportApproved(short reportId)
        {
            return await Dal.functions.reportFun.checkIsReportApproved(reportId);
        }

        public static async Task< int> ApproveReceiptsInReport(string phone, short reportId)
        {
            //check if the getter is existed
            Dal.Models.Member tempMember =await Dal.functions.memberFun.getMemberByPhone(phone);
            if (tempMember == null)
                return 0;
            //update the getter to approved
            int res =await Dal.functions.reportFun.ApproveReceiptsInReport(phone, reportId) ? 1 : 0;
            if (res == 1)
                return res;
            //less the time for getter
            TimeSpan repHours =await Dal.functions.reportFun.getTimeOfReportById(reportId);
            int hours, minuts;
            hours = repHours.Hours;
            minuts = repHours.Minutes;
            TimeSpan addHours = new TimeSpan(hours, minuts, 0);
          await  Dal.functions.reportFun.updateHours(phone, -addHours);



            // add the time for giver by check if all the getter is approved 
            if (await checkIsReportApproved(reportId))
            {
                string phoneGiver=(await Dal.functions.memberFun.getMemberByPhone(phone)).Phone;
               await Dal.functions.reportFun.updateHours(phoneGiver, addHours);
                return res+1;
            }
            return res;

        }
    }
}
