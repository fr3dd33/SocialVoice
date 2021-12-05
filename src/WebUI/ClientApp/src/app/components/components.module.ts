import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {FooterComponent} from "./footer/footer.component";
import {HeaderComponent} from "./header/header.component";
import { IssueCardComponent } from './issue-card/issue-card.component';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [
    FooterComponent,
    HeaderComponent,
    IssueCardComponent
  ],
  imports: [
    CommonModule,
    RouterModule
  ],
  exports: [
    FooterComponent,
    HeaderComponent,
    IssueCardComponent,
  ]
})
export class ComponentsModule { }
