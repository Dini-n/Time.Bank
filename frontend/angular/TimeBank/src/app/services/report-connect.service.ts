import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ReportsAndDetails } from '../classes/reports-and-details';
import { UrlsService } from './urls.service';
import { PostReport } from '../classes/reports-and-all-details';

@Injectable({
  providedIn: 'root'
})
export class ReportConnectService {

  
  reportController = "report/"
  constructor(private http:HttpClient , private urls:UrlsService) { }
 urlApi = this.urls.urlApi;

getAllReport():Observable<Array<ReportsAndDetails>>
  {
    return this.http.get<Array<ReportsAndDetails>>(this.urlApi + this.reportController+"GetAllReport");
  }
  // addReport(phone: string, categoryName: string, rep: ReportsAndDetails): Observable<boolean> {
  //   return this.http.post<boolean>(`${this.urlApi}${this.reportController}addReport/${phone}/${categoryName}`, rep);
  // }


 addReport(report:PostReport): Observable<boolean> {
  // rep.receivers.push(new Receiver("Dina Nairner","0773009079"));
  // this.r.categoryName=categoryName;
  // this.r.phone=phone;
  // this.r.reportsAndDetail=rep;
 const hour= report.reportsAndDetail.time.toString().substring(0,2)
 const minutes= report.reportsAndDetail.time.toString().substring(3,5)

    return this.http.post<boolean>(this.urlApi+this.reportController+"addReport", 
    {
      "phone": report.phone,
      "categoryName": report.categoryName,
      "reportsAndDetail": {
        "date": report.reportsAndDetail.date,
        "time": {
          "hours": hour,
          "minutes":minutes
        },
        "note":report.reportsAndDetail.note,
        "getterMembers":report.reportsAndDetail.getterMembers,
        "receiverApproved": report.reportsAndDetail.recieverApproved
      }
    }
    
    );
  
}

 
}

 // {
  //   "phone":report.phone,
  //   "categoryName":report.categoryName,
  //   "reportsAndDetail": {
  //     "date": report.reportsAndDetail.date,
  //     "time": report.reportsAndDetail.time,
  //     "note": report.reportsAndDetail.note,
  //     "getterMembers": [
  //       {
  //         "name": "Dina Nairner",
  //         "phone": "0773009079"
  //       }
  //     ],
  //     "receiverApproved": report.reportsAndDetail.recieverApproved
  //   }
  // }

