import { Component, OnInit } from '@angular/core';
import { IssueService, IssuesListDto } from "../../services/social-voice-api";
import FingerprintJS from "@fingerprintjs/fingerprintjs";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {

  issues: IssuesListDto[];
  searchText = "";
  total: number = 0;
  lastParams = {
    limit: 10,
    offset: 0,
    search: ""
  }
  visitorId = "";

  constructor(
    private issueService: IssueService
  ) {
    this.getVisitorID();
  }

  public getVisitorID(): void {
    FingerprintJS.load()
      .then((fp) => fp.get())
      .then((result) => {
        this.visitorId = result.visitorId;
      });
  }

  ngOnInit() {
    this.onGet();
  }

  onGet() {
    this.issueService.getAll(
      this.lastParams.limit,
      this.lastParams.offset,
      this.lastParams.search
    ).subscribe(issues => {
      this.issues = issues.data;
      this.total = issues.total;
    });
  }

  onSearch() {
    this.lastParams = {
      limit: 10,
      offset: 0,
      search: this.searchText
    };
    this.onGet();
  }

  onUpdate() {
    this.onGet();
  }
}
