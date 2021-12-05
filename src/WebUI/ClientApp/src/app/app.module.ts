import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import {ComponentsModule} from "./components/components.module";
import {OrganizationsComponent} from "./organizations/organizations.component";
import {IssueInfoComponent} from "./issue/issue-info/issue-info.component";
import {IssueAddComponent} from "./issue/issue-add/issue-add.component";

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    OrganizationsComponent,
    IssueInfoComponent,
    IssueAddComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    ComponentsModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
