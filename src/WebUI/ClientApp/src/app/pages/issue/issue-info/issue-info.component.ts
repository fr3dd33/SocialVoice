import { Component, OnInit } from '@angular/core';
import { IssueDetailDto, IssueService } from "../../../services/social-voice-api";
import { ActivatedRoute } from "@angular/router";

@Component({
  selector: 'app-issue-info',
  templateUrl: './issue-info.component.html',
  styleUrls: ['./issue-info.component.css']
})
export class IssueInfoComponent implements OnInit {
  issue: IssueDetailDto
  id: any;

  constructor(private service: IssueService, private router: ActivatedRoute) { }

  ngOnInit() {
    this.router.params.subscribe(params => this.id = params["id"])
    this.service.get(this.id).subscribe(response => this.issue = response);
  }
}
