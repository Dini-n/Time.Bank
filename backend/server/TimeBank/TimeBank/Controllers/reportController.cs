using Dto.dtoClasses;
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
    public class reportController : ControllerBase
    {


        [HttpPost("addReport")]
        public async Task< ActionResult<bool>> addReport( Dto.dtoClasses.ReportDto report)
        {
            //add checking of all the details if null exc.

            if (report == null ||report.getterMembers == null || report.getterMembers.Count == 0
                ||(report.time.hours == 0 && report.time.minutes == 0))
                return Ok(false);
            bool isCorrectInput =await Bll.functions.reportFunction.addReport(report);
            return Ok(isCorrectInput);
        }
     




    }
}

