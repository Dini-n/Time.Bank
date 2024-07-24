import { Component, Inject, OnInit, Output, ViewChild } from '@angular/core';
import { MemberConnectService } from './services/member-connect.service';
import { LoginComponent } from './components/account/login/login.component';
import { CurrentUserService } from './services/current-user.service';
import { DOCUMENT } from '@angular/common';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{

  title = 'bank-time';
  isLoggedIn = false;

  constructor(public currentUserService: CurrentUserService) { }

  ngOnInit() {
    this.isLoggedIn = this.currentUserService.currentMember && this.currentUserService.currentMember.phone !== "";
  }

  logout() {
    this.currentUserService.clearCurrentUser();
    this.isLoggedIn = false;
  }
}
