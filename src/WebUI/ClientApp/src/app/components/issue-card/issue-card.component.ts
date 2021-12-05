import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { IssueService, IssuesListDto } from "../../services/social-voice-api";
import { ToastrService } from "ngx-toastr";

@Component({
  selector: 'app-issue-card',
  templateUrl: './issue-card.component.html',
  styleUrls: ['./issue-card.component.css']
})
export class IssueCardComponent implements OnInit {
  @Input() issue: IssuesListDto;
  @Output() update: EventEmitter<any> = new EventEmitter<any>();

  constructor(private service: IssueService, private toastr: ToastrService) { }

  ngOnInit() {
  }

  onPro() {
    this.service.votePro({ id: this.issue.id }).subscribe(
      response => {
        this.toastr.success('Ваш голос был принят', 'Успешно', { timeOut: 5000 });
        this.update.emit();
      }, error => {
        if (Array.isArray(error.errors)) {
          error.errors.forEach(x => {
            this.toastr.error('Ваш голос не может превышать больше одного раза', 'Ошибка', { timeOut: 5000 });
          });
        }
      }
    )
  }

  onCos() {
    this.service.voteCon({ id: this.issue.id }).subscribe(
      response => {
        this.update.emit();
      }, error => {
        error.errors.forEach(x => {
          this.toastr.error('Ваш голос не может превышать больше одного раза', 'Ошибка', { timeOut: 5000 });
        });
      }
    )
  }
}
