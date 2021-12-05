import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { ComponentsModule } from "./components/components.module";
import { HomeComponent } from './pages/home/home.component';
import { IssueInfoComponent } from "./pages/issue/issue-info/issue-info.component";
import { IssueAddComponent } from "./pages/issue/issue-add/issue-add.component";
import { OrganizationInfoComponent } from './pages/organization/organization-info/organization-info.component';
import { OrganizationListComponent } from './pages/organization/organization-list/organization-list.component';
import { AppRoutingModule } from './app-routing.module';
import { RouterModule } from '@angular/router';
import { IssueService, OrganizationService } from './services/social-voice-api';
import { MissionComponent } from "./pages/mission/mission.component";
import { ToastrModule } from "ngx-toastr";

@NgModule({
  declarations: [
    AppComponent,
    OrganizationListComponent,
    OrganizationInfoComponent,
    IssueInfoComponent,
    IssueAddComponent,
    HomeComponent,
    MissionComponent
  ],
  imports: [
    BrowserModule.withServerTransition({appId: 'ng-cli-universal'}),
    HttpClientModule,
    ComponentsModule,
    FormsModule,
    RouterModule,
    AppRoutingModule,
    ToastrModule.forRoot()
  ],
  providers: [
    IssueService,
    OrganizationService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
