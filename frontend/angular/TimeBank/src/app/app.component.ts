import { Component, OnInit } from '@angular/core';
import { MemberConnectService } from './services/member-connect.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{

  constructor(private con:MemberConnectService) { }

  ngOnInit(): void {
  this.con.loadAllMambers();
  }
  title = 'angular';
}
