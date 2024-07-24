import { Component, OnInit } from '@angular/core';
import { NgModel } from '@angular/forms';
import { Category } from 'src/app/classes/category';
import { Receiver } from 'src/app/classes/receiver';
import { PostReport } from 'src/app/classes/reports-and-all-details';
import { ReportsAndDetails } from 'src/app/classes/reports-and-details';
import { CurrentUserService } from 'src/app/services/current-user.service';
import { ReportConnectService } from 'src/app/services/report-connect.service';

@Component({
  selector: 'app-new-report',
  templateUrl: './new-report.component.html',
  styleUrls: ['./new-report.component.css']
})
export class NewReportComponent implements OnInit {
  /** הערה חשובה--------חלק זה מיועד רק להוספת דיווח ולא לשינוי ה */
  //בשביל שינוי נעשה קומפוננטה חדשה לעדכון בגלל הקוד הארוך והמייגע
  countReciveTS:number=0;
  isEnterMember:boolean=false;
  postReport:PostReport=new PostReport(0,"","","","",new Date(),{hours: 0,minutes:0} ,"",[],false);

  //דיווח
  //report:ReportsAndDetails=new ReportsAndDetails(new Date(),{hours: 0,minutes:0} ,"",[],false);
  //רשימת הקטגוריות של החבר ימופה כדי שלא יהיה סתם את הדיווחים עבור החבר בשביל רק  בחירת שמות הקטגוריות שלו
  listCategory:Array<Category>=[];
  //הקטגוריה שנבחרה נקבל משהמשתמש שם
  //categoryName:string="";
 //בנאי
  constructor(private con:ReportConnectService ,public user:CurrentUserService) { }
  ngOnInit(): void {
    this.listCategory=this.user.currentMember.categories.map(c=>c.category);
    console.log(this.listCategory.toString());
    //this.postReport.reportsAndDetail.getterMembers=new Array<Receiver>(this.countReciveTS);

  }

//פונקציית השמירה
  onSave(){
      this.postReport.getterMembers.push(new Receiver("Dina Nairner","0773009079"));
  // this.postReport.categoryName=this.categoryName;
   this.postReport.phoneGive=this.user.currentMember.phone;
       this.con.addReport(this.postReport).subscribe(     
         (data) => 
        {
          if(data == false)
             { alert("אנא בדוק את הקלט - העדכון נכשל"); return;}
          else
          alert("הדיווח הושלם בהצלחה");
         },
        (err) => 
       {
         alert(err.message);
        }
       );
   }

    
   updateReceivers() {
    var countCurrentRecive=this.postReport.getterMembers.length;
    if(this.countReciveTS>countCurrentRecive)
    for(let i=0; i< this.countReciveTS-countCurrentRecive; i++){
      this.postReport.getterMembers.push(new Receiver("",""));
    }
    else{
      this.postReport.getterMembers=[];
      for(let i=0; i< this.countReciveTS; i++){
        this.postReport.getterMembers.push(new Receiver("",""));
      }
    }

   /* this.isEnterMember=true;
   
    const currentCount = this.report.receivers.length;

    if (this.countReciveTS > currentCount) {
      const diff = this.countReciveTS  - currentCount;
      
    for (let i = 0; i < this.countReciveTS; i++) {
      this.report.receivers.push({ phone: '', name: '' });
      console.log("hi");
      
    }
    } else {
      this.report.receivers = this.report.receivers.slice(0, this.countReciveTS );
    }*/
  }
  
}
