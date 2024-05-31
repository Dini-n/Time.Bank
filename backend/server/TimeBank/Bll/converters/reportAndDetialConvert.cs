using Dto.dtoClasses;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.converters
{
    public class reportAndDetialConvert//:IEnumerable
    {
        public static Dto.dtoClasses.ReportAndDetailDto convertFromMicToDto(Dal.Models.Report report )
        {
            Dto.dtoClasses.ReportAndDetailDto r = new Dto.dtoClasses.ReportAndDetailDto();
            r.date = report.Date;
            //כאן יש צורך לעשות לולאה עבור כל חברי הפעולה שקבלו.
            //ההמרה מתבצעת לרשימה כדי לגשת למקום הראשון כי יש חבר אחד
            //בניית החבר היחיד בינתיים שמקבל את הפעולה
            if (report.ReportsDetails.Count() != 0)
            {
               // r.GetterMembers = new Dto.dtoClasses.Receiver(report.ReportsDetails.ToList()[0].GetterMember.Name, report.ReportsDetails.ToList()[0].GetterMember.Phone);
                List<Dto.dtoClasses.Receiver> gM = new List<Dto.dtoClasses.Receiver>();
                for (int i = 0; i < report.ReportsDetails.ToList().Capacity; i++)
                {
                    gM.Add(new Dto.dtoClasses.Receiver(report.ReportsDetails.ToList()[i].GetterMember.Name, report.ReportsDetails.ToList()[0].GetterMember.Phone));
                }
                r.getterMembers = gM;
                List<bool> appr = new List<bool>();
                ///????????
                r.receiverApproved = report.ReportsDetails.ToList().FirstOrDefault(x => x.ReceiverApproved == false) == null;
            }
            r.time =new Dto.dtoClasses.Time( report.Hour.Hours,report.Hour.Minutes);
            r.Note = report.Note;
            return r;
        }
        // (ממנו למיקרוסופט (חבר
/*        public static Dal.Models.Report convertFromDtoToMicro(Dto.dtoClasses.ReportsAndDetail report)
        {

            Dal.Models.Report r = new Dal.Models.Report();
            r.Date = report.Date;
            //כאן יש צורך לעשות לולאה עבור כל חברי הפעולה שקבלו.
            //ההמרה מתבצעת לרשימה כדי לגשת למקום הראשון כי יש חבר אחד

            for (int i = 0; i < report.GetterMembers.Capacity; i++)
            {
             r.ReportsDetails.Add(new Dal.Models.ReportsDetail()
            { 
                    GetterMemberId = Dal.functions.memberFun.getMemberByPhone(report.GetterMembers[i].phone).Id,
                    ReceiverApproved = report.ReceiverApproved
                    ,GetterMember = Dal.functions.memberFun.getMemberByPhone(report.GetterMembers[i].phone)
                   
            });
            }
           
            return r;
        }*/
        public static Dal.Models.Report convertFromDtoToMicroWhithRouter(Dto.dtoClasses.ReportAndDetailDto report, string categoryName,string phone)
        {
            //Dal.Models.Report r = convertFromDtoToMicro(report);
            //r.Category.CategoryId = Dal.functions.categoryFun.GetAllCategories().FirstOrDefault(c => c.Name == categoryName).Id;
            Dal.Models.Report r = new Dal.Models.Report();
            r.Date = report.date;
            Dal.Models.Member tempMember = Dal.functions.memberFun.getMemberByPhone(phone);
            if (tempMember == null)
                return null;
            Dal.Models.MemberCategory c = tempMember.MemberCategories.FirstOrDefault(x => x.Category.Name == categoryName);
            if (c == null)
                return null;
            r.MemberCategoryId = c.Id;
            //r.Giver = Dal.functions.memberFun.GetAllMembers().FirstOrDefault(m => m.Phone == phone);
            
            r.Hour = new TimeSpan(report.time.hours, report.time.minutes, 0);
            r.Note = report.Note;
            return r;
        }
        public static List<Dal.Models.ReportsDetail> convertReceiversListFromDtoToMicro(List<Dto.dtoClasses.Receiver> receiversList, short reportID)
        {
            List<Dal.Models.ReportsDetail> reportDetails = new List<Dal.Models.ReportsDetail>();
            foreach (var item in receiversList)
            {
                Dal.Models.ReportsDetail repDetails = convertReceiverFromDtoToMicro(item, reportID);
                if (repDetails != null)
                    reportDetails.Add(repDetails);
                else
                    return null;
            }
            return reportDetails;
        }
        //convert receivers
        public static Dal.Models.ReportsDetail convertReceiverFromDtoToMicro(Dto.dtoClasses.Receiver receiver, short reportID)
        {
            Dal.Models.ReportsDetail repDetails = new Dal.Models.ReportsDetail();
            repDetails.ReportId = reportID;
            Dal.Models.Member tempMember = Dal.functions.memberFun.getMemberByPhone(receiver.phone);
            if (tempMember == null)
                return null;
            repDetails.GetterMemberId = tempMember.Id;
            repDetails.ReceiverApproved = false;
            return repDetails;
        }
        // ממיר רשימה של מיקרוסופט אלנו
        public static List<Dto.dtoClasses.ReportAndDetailDto> ConvertListFromMicToDto(List<Dal.Models.Report> microMemberList)
        {
            List<Dto.dtoClasses.ReportAndDetailDto> lm = new List<Dto.dtoClasses.ReportAndDetailDto>();
            microMemberList.ForEach(m => lm.Add(convertFromMicToDto(m)));
            return lm;
        }

        // ממיר רשימה שלנו למיקרוסופט
   /*     public static List<Dal.Models.Report> ConvertListDtoToMic(List<Dto.dtoClasses.ReportsAndDetail> dto)
        {
            List<Dal.Models.Report> mic = new List<Dal.Models.Report>();
            dto.ForEach(m => mic.Add(convertFromDtoToMicro(m)));
            return mic;
        }*/

     /*   public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }*/
    }
}
