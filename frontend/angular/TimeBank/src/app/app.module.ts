import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { MyAccountComponent } from './components/account/my-account.component';
import { ReportsComponent } from './components/reports/reports.component';
import { SetActionComponent } from './components/set-action/set-action.component';
import { AboutComponent } from './components/about/about.component';
import { ViewMembersComponent } from './components/view-member/view-members/view-members.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
//-------------sub---------------//
import { NewMemberComponent } from './components/view-member/new-member/new-member.component';
import { ViewCategoriesComponent } from './components/set-action/getFromBT/view-categories/view-categories.component';
// import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

//------------materials------------//
import { MatModule } from './modules/mat/mat.module';
import { AddCategoryComponent } from './components/set-action/getFromBT/add-category/add-category.component';
import { MemberCategotiesComponent } from './components/account/member-categories/member-categoties/member-categoties.component';
import { LoginComponent } from './components/account/login/login.component';
import { FormReportComponent } from './components/reports/reportsSub/form-report/form-report.component';
import { ActionDetielsComponent } from './components/set-action/action-detiels/action-detiels.component';
import { NewReportComponent } from './components/reports/reportsSub/new-report/new-report.component';
import { ApproveComponent } from './components/reports/reportsSub/approve/approve.component';
import { SearchByCategoryComponent } from './components/set-action/search/search-by-category/search-by-category.component';
import { SearchByStringComponent } from './components/set-action/search/search-by-string/search-by-string.component';
import { CategoryReportsComponent } from './components/account/member-categories/category-reports/category-reports.component';
import { ReceivedReportsComponent } from './components/account/received-reports/received-reports.component';
import { AddMemberCategoryComponent } from './components/account/member-categories/add-member-category/add-member-category.component';
import { ReceivedReportsNeedApproveComponent } from './components/account/received-reports/received-reports-need-approve/received-reports-need-approve.component';

//import {ModelModule} from './modules/model/model.module'


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    MyAccountComponent,
    ReportsComponent,
    SetActionComponent,
    AboutComponent,
    ViewMembersComponent,
    NewMemberComponent,
    ViewCategoriesComponent,
    AddCategoryComponent,
    MemberCategotiesComponent,
    LoginComponent,
    FormReportComponent,
    ActionDetielsComponent,
    NewReportComponent,
    ApproveComponent,
    SearchByCategoryComponent,
    SearchByStringComponent,
    CategoryReportsComponent,
    ReceivedReportsComponent,
    AddMemberCategoryComponent,
    ReceivedReportsNeedApproveComponent,
    
    //AboutComponent,
  ],
  imports: [
    RouterModule,
    BrowserModule,
    AppRoutingModule,
    MatModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    // ModelModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
