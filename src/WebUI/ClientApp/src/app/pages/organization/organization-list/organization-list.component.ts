import { Component, OnInit } from '@angular/core';
import { OrganizationService, OrganizationsListDto } from "../../../services/social-voice-api";

@Component({
  selector: 'app-organization-list',
  templateUrl: './organization-list.component.html',
  styleUrls: ['./organization-list.component.css']
})
export class OrganizationListComponent implements OnInit {
  organizations: OrganizationsListDto[];

  constructor(private orgService: OrganizationService) { }

  ngOnInit() {
    this.orgService.getAll(1000, 0, null).subscribe(
      response => {
        this.organizations = response.data
      }
    )
  }

}
