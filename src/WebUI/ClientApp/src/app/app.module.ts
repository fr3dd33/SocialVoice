import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import {ComponentsModule} from "./components/components.module";
import {IssueInfoComponent} from "./issue/issue-info/issue-info.component";
import {IssueAddComponent} from "./issue/issue-add/issue-add.component";
import { OrganizationInfoComponent } from './organization/organization-info/organization-info.component';
import { OrganizationListComponent } from './organization/organization-list/organization-list.component';
import { AppRoutingModule } from './app-routing.module';
import { RouterModule } from '@angular/router';
import { IssueService, OrganizationService } from './services/social-voice-api';

@NgModule({
  declarations: [
    AppComponent,
    OrganizationListComponent,
    OrganizationInfoComponent,
    IssueInfoComponent,
    IssueAddComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    ComponentsModule,
    FormsModule,
    RouterModule,
    AppRoutingModule
  ],
  providers: [
    IssueService,
    OrganizationService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
