import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Member } from 'src/app/classes/member';
import { Time } from '@angular/common';
import { MemberConnectService } from 'src/app/services/member-connect.service';



@Component({
  selector: 'app-new-member',
  templateUrl: './new-member.component.html',
  styleUrls: ['./new-member.component.css']
})
export class NewMemberComponent implements OnInit {
  newMember:Member = new Member("","","","","",1950,true , {hours:0,minutes:0},true,true);
  whichGender:string="";
  @Input() btnContent:string="";
  @Input() isToCheck:boolean=true;
  close:boolean = false;
  constructor(private con:MemberConnectService ) { }
  ngOnInit(): void {
  }
  onSave(){
    this.newMember.toCheck = this.isToCheck;
    if(this.whichGender == "1")
         this.newMember.gender = true;
    else
        this.newMember.gender = false;

    if(this.newMember.name=="" || this.newMember.phone=="" || this.newMember.yearBorn == 1900
    || this.newMember.password=="")
    return;
    else{
    this.con.addMember(this.newMember).subscribe(
        
        (data) => 
        {
          if(data == null)
            { alert("nooooo"); return;}
          alert("add");
          // this.newMember.(data);
          console.log(this.newMember.name); 
        localStorage.setItem("currentUser",this.newMember.phone)  
        //לעשות מוסתר כדי שבבדיקה לא יראו את הסיסמה
         localStorage.setItem("currentUser",this.newMember.password)    
  
        },
        (err) => 
        {
          alert(err.message);
        }
      );
  }
  }
}
