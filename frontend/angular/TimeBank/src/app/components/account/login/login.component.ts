import { Component, OnInit } from '@angular/core';
import { Member } from 'src/app/classes/member';
import { CurrentUserService } from 'src/app/services/current-user.service';
import { MemberConnectService } from 'src/app/services/member-connect.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private con:MemberConnectService, private curUser:CurrentUserService) { }
  newMember:Member = new Member("","","","","",1950,true , {hours:0,minutes:0},true,true);
  
   //chana
   btnCont:string ="Sign in";
   check:boolean=true;
   //
  phone:string="";

  password:string="";
  ngOnInit(): void {
    
  }
    
    // onSubmit() {
    //   const isLoggedIn = this.curUser.currentMember(this.phone, this.password);
    //   if (isLoggedIn) {
    //     localStorage.setItem('isLoggedIn', 'true');
    //     localStorage.setItem('email', this.phone);
    //   }
    // }
  
  onSave(){
   this.con.checkMemberByPhoneAndPass(this.phone , this.password).subscribe(

  (data)  => 
   {
    if(data == null)
   {
    alert("חבר זה אינו מופיע במערכת אנא בדוק את תקינות הקלט והסיסמה או הגש מועמדות להיות חבר בבנק");
  this.phone = "";
  this.password = ""; 
  }
      if(data.gender == true)
          alert("ברוך הבא " + data.name)
        else
          alert("ברוכה הבאה " +data.name)
          //עדכון מי החבר העכשווי
        this.curUser.setCurrentUser(data);
        //console.log(this.curUser.currentMember.name); 
        localStorage.setItem("currentUser",this.phone);
        localStorage.setItem("currentPass",this.password);
        this.ngOnInit();
   },
   (err) => 
   {
     alert(err.message);
   }
 );
  }
}

