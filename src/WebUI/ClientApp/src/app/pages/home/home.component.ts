import { Component, OnInit } from '@angular/core';
import { IssueService, IssuesListDto } from "../../services/social-voice-api";

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

  constructor(
    private issueService: IssueService
  ) {

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
}
