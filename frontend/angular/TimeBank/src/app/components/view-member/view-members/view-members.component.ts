import { ChangeDetectionStrategy, Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Member } from 'src/app/classes/member';
import { MemberConnectService } from 'src/app/services/member-connect.service';
import { NgZone, ChangeDetectorRef } from '@angular/core';

@Component({
  selector: 'app-view-members',
  templateUrl: './view-members.component.html',
  styleUrls: ['./view-members.component.css'],//  changeDetection: ChangeDetectionStrategy.OnPush

})
export class ViewMembersComponent implements OnInit {
members:Array<Member> = [];
btnCont:string="הכנס חבר חדש";
notCheck:boolean=false;
constructor(private cdr: ChangeDetectorRef,private con:MemberConnectService,private zone: NgZone) { }

  ngOnInit(): void {
    this.members = this.con.members;
    console.log(this.members+"woooooo");
    this.start();
  }
  start(){
   //this.loadData();
    }
 // פונקציה שמקבלת את תוצאות הקריאה מהשרת ומפרקת למקרה של הצלחה וכישלון
  loadData()
  {
  //while(!this.con.filled){}
  
  }
  //-------------פונקציות שמחזירות את הערכים בצורה קריאה---------//
  // מחזיר את הזמן
  getRemainTime(mem:Member){
   return(mem.remainingHours.hours + ":" + mem.remainingHours.minutes);
  }
// מחזיר את המין
  getGender(mem:Member){
    if(mem.gender == true)
       return 'ז';
      return 'נ';
  }
  // מחזיר האם פעיל או לא
  getActive(mem:Member){
    if(mem.active == true)
    return 'כן';
   return 'לא';
  }
  // פעולה שמאשרת חבר מסוים
  aproveMember(m:Member){
    let ans =  confirm(" האם אתה רוצה לאשר את החבר " + m.name + "\n" +" שמספרו " + m.phone);
    if(ans.valueOf()==true)
    {
      this.con.approveMember(m.phone).subscribe(
        (myData)=>
        { 
         alert("החבר אושר בהצלחה")
         this.refreshTableOfMembers();
         },
         (myErr)=>
         {  alert(myErr.message);}
        );
    }
  }
 
  
  removeMember(m:Member){
  // מוחק חבר מהרשימה כלומר קורא לפונ מחיקה מהסרביס ומפרק אותה
  }
  addMember(){
  // שם כאן את הקומפוננטה של הוספת חבר של המשתמש
  }
  
refreshTableOfMembers(){
 // this.cdr.detectChanges(); // Trigger change detection

 this.con.getAllMembers().subscribe(
 (data)=>{
  this.con.members=data;
   this.members = data;
 },
 (err)=>{
 alert(err.message);
 }
 )
 

  // this.con.loadAllMambers();
  // this.members=this.con.members;
  // this.zone.run(() => {
  //   setTimeout(() => {
  //     this.cdr.detectChanges(); // רענון הטבלה
  //   });
  // });
  // this.members=this.con.members;

}

switchActive(m:Member,b:boolean){
  let ans =  confirm(" האם אתה רוצה להפוך את מצב החבר " + m.name + "\n" +" שמספרו " + m.phone);
  if(ans.valueOf()==true)
  {
    this.con.swichActive(m.phone,b).subscribe(
      (myData)=>
      { 
       alert("מצב החבר התהפך");
       this.con.loadAllMambers();
       this.members=this.con.members;
       },
       (myErr)=>
       {  alert(myErr.message);}
      );
  }
  this.refreshTableOfMembers();

}
}

