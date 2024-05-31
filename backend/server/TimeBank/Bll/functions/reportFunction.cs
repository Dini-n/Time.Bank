using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.functions
{
    public  class reportFunction
    {
        public static bool addReport(string phone, string categoryName,Dto.dtoClasses.ReportAndDetailDto rep)
        {
            //TODO
            //1. add report
            //2. add report details
           
            Dal.Models.Report tempReport = Bll.converters.reportAndDetialConvert.convertFromDtoToMicroWhithRouter(rep, categoryName, phone);
            //if there is no member with this phone
            if (tempReport == null)
                return false;
            //if there is not correct phone
            if (!Dal.functions.reportFun.checkCorrectInputRec(rep.getterMembers.Select(p => p.phone).ToList()))
                return false;
            short reportID = Dal.functions.reportFun.addReport(tempReport);
            List<Dal.Models.ReportsDetail> reportsDetails = Bll.converters.reportAndDetialConvert.convertReceiversListFromDtoToMicro(rep.getterMembers, reportID);
            /////////////////////////
            if (reportsDetails == null)
            {
                return false;
                //delete what we added
                //לבדוק קודם תקינות אולי של כל הטלפונים ואז להכניס במקום להכניס ולמחוק
                Dal.functions.reportFun.deleteReportById(reportID);
            }
            ///////////////////////////  
            Dal.functions.reportFun.addReportDetails(reportsDetails);
            return true;
        }

        public static bool checkIsReportApproved(short reportId)
        {
            return Dal.functions.reportFun.checkIsReportApproved(reportId);
        }

        public static int getterAproveReport(string phone, short reportId)
        {
            Dal.Models.Member tempMember = Dal.functions.memberFun.getMemberByPhone(phone);
            if (tempMember == null)
                return 0;
             int res = Dal.functions.reportFun.getterAproveReport(tempMember.Id, reportId) ? 1:0;
            if(checkIsReportApproved(reportId))
            {
                TimeSpan repHours = Dal.functions.reportFun.getTimeOfReportById(reportId);
                int hours, minuts;
                int gettersNum = Dal.functions.reportFun.getNumOfGettersOfReportById(reportId);
                //TODO use algorithem of hours
                /////////////////////////////////
                hours = repHours.Hours;
                minuts = repHours.Minutes;
                // for the begining we will just update the hours he put
                TimeSpan addHours = new TimeSpan(hours, minuts,0);
                Dal.functions.reportFun.updateHours(phone, addHours);
                return 2;
            }
            return res;

        }
    }
}
