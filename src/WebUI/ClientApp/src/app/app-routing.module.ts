import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { IssueAddComponent } from './pages/issue/issue-add/issue-add.component';
import { IssueInfoComponent } from './pages/issue/issue-info/issue-info.component';
import { OrganizationInfoComponent } from './pages/organization/organization-info/organization-info.component';
import { OrganizationListComponent } from './pages/organization/organization-list/organization-list.component';
import { MissionComponent } from "./pages/mission/mission.component";

const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'mission', component: MissionComponent },
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
