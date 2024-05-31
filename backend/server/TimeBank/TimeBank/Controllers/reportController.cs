using Dto.dtoClasses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace TimeBank.Controllers
{
    public class PostReport
    {
        public string phone { get; set; }
        public string categoryName { get; set; }
        public Dto.dtoClasses.ReportAndDetailDto reportsAndDetail {  get; set; }    

    }
    [Route("api/[controller]")]
    [ApiController]
    public class reportController : ControllerBase
    {


        [HttpPost("addReport")]
        public ActionResult<bool> addReport( PostReport reeport)
        {
            //add checking of all the details if null exc.

            if (reeport.reportsAndDetail == null ||reeport.reportsAndDetail.getterMembers == null || reeport.reportsAndDetail.getterMembers.Count == 0
                ||(reeport.reportsAndDetail.time.hours == 0 && reeport.reportsAndDetail.time.minutes == 0))
                return Ok(false);
            bool isCorrectInput = Bll.functions.reportFunction.addReport(reeport.phone, reeport.categoryName, reeport.reportsAndDetail);
            return Ok(isCorrectInput);
        }

        [HttpPut("getterAproveReport/{phone}/{reportId}")]
        public ActionResult<int> getterAproveReport(string phone , short reportId)
        {
            try
            {
                int sec = Bll.functions.reportFunction.getterAproveReport(phone, reportId);
                /*פה לקרוא לפונקציות של השכבות מתחת שלוקחות את החבר שנשלח ופשוט משנות את הערך של צק לשקר*/
                return Ok(sec);
            }
            catch
            { return BadRequest(0); }

        }




    }
}

