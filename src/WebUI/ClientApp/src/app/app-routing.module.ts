import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { IssueAddComponent } from './issue/issue-add/issue-add.component';
import { IssueInfoComponent } from './issue/issue-info/issue-info.component';
import { OrganizationInfoComponent } from './organization/organization-info/organization-info.component';
import { OrganizationListComponent } from './organization/organization-list/organization-list.component';

const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'issues/add', component: IssueAddComponent },
  { path: 'issues/:id', component: IssueInfoComponent },
  { path: 'organizations', component: OrganizationListComponent },
  { path: 'organizations/:id', component: OrganizationInfoComponent },
]

@NgModule({
  imports: [
    CommonModule,
    BrowserModule,
    RouterModule.forRoot(routes)
  ],
  exports: [],
})
export class AppRoutingModule { }
