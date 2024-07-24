import { Injectable } from '@angular/core';
import { Member } from '../classes/member';

@Injectable({
  providedIn: 'root'
})
export class CurrentUserService {
  currentMember: Member;

  constructor() { 
    const storedMember = localStorage.getItem('currentMember');
    if (storedMember) {
      this.currentMember = JSON.parse(storedMember);
    } else {
      this.currentMember = new Member("","","","","",1950,true, {hours:0,minutes:0},true,true);
    }
  }

  setCurrentUser(m: Member) {
    this.currentMember = m;
    localStorage.setItem('currentMember', JSON.stringify(m));
  }

  clearCurrentUser() {
    this.currentMember = new Member("","","","","",1950,true, {hours:0,minutes:0},true,true);
    localStorage.removeItem('currentMember');
  }
}