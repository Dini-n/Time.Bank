import { Component, OnInit } from '@angular/core';
import { Member } from 'src/app/classes/member';
import { CurrentUserService } from 'src/app/services/current-user.service';
import { MemberConnectService } from 'src/app/services/member-connect.service';
import { NewMemberComponent } from '../view-member/new-member/new-member.component';

@Component({
  selector: 'app-my-account',
  templateUrl: './my-account.component.html',
  styleUrls: ['./my-account.component.css']
})

export class MyAccountComponent implements OnInit {
  currentMember:Member = new Member("","","","","",1950,true , {hours:0,minutes:0},true,true);
  constructor(private curMemberService:CurrentUserService,private memberCon:MemberConnectService) { 
    //this.returnCurrent();
    this.currentMember = curMemberService.currentMember;
    console.log("const")

  }
 
  ngOnInit(): void {
  }
  getRemainTime(mem:Member){
    return(mem.remainingHours.hours + ":" + mem.remainingHours.minutes);
   }
// להצפין את הסיסמה?
// יש אפשרות לdefine? - currentUser...
   localUser:string | null=localStorage.getItem("currentUser");
   localPass:string | null=localStorage.getItem("currentPass");
   phone:string="";
   password:string="";
   returnCurrent(){
    if(this.localUser!=null && this.localPass != null){
      this.phone=this.localUser;
      this.password = this.localPass;
    this.memberCon.checkMemberByPhoneAndPass(this.phone , this.password).subscribe(
 
   (data)  => 
    {
     if(data == null)
     {
      alert("חבר אינו מופיע במערכת אנא בדוק את תקינות הקלט או הגש מועמדות להיות חבר בבנק");
      localStorage.removeItem("currentUser")
      localStorage.removeItem("currentPass")
     }
     
     this.currentMember=data;
     this.curMemberService.currentMember = data;
    },
    (err) => 
    {
      alert(err.message);

    }
  );
   }
         
  }
}
