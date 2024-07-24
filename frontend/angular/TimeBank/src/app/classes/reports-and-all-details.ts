import { Time } from "@angular/common";
import { Receiver } from "./receiver";
import { ReportsAndDetails } from "./reports-and-details";
import { publishFacade } from "@angular/compiler";

export class PostReport {

   
    constructor(
        public idReport:number,
        public namgGive:string,
        public mailGive:string,
        public  phoneGive:string,
            public  categoryNameGive:string,
            public date:Date,
            public time:Time,
            public note:string,
            public  getterMembers:Array<Receiver>,
            public recieverApproved:boolean ){}
}
