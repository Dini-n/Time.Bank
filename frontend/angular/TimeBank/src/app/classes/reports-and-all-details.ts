import { Time } from "@angular/common";
import { Receiver } from "./receiver";
import { ReportsAndDetails } from "./reports-and-details";

export class PostReport {
    constructor(
        public  phone:string,
            public  categoryName:string,
            public reportsAndDetail:ReportsAndDetails ){}
}
