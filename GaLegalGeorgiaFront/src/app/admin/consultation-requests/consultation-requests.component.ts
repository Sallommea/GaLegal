import { Component, OnInit } from '@angular/core';
import { ConsultationEmail } from 'src/app/models/consultationRequest.model';

import { ConsultationRequestsService } from 'src/app/services/consultation-requests.service';

@Component({
  selector: 'app-consultation-requests',
  templateUrl: './consultation-requests.component.html',
  styleUrls: ['./consultation-requests.component.css'],
})
export class ConsultationRequestsComponent implements OnInit {
  consultationRequests: ConsultationEmail[] = [];
  itemsPerPage: number = 8;
  currentPage: number = 1;
  pagesArray: number[] = [];
  lang: string;
  status: string = 'status';
  messages: string;

  constructor(private requestsService: ConsultationRequestsService) {}
  ngOnInit(): void {
    this.requestsService
      .getPaginated(this.currentPage, this.itemsPerPage)
      .subscribe((res) => {
        this.consultationRequests = res.resultList;
        this.pagesArray = Array(res.totalPages)
          .fill(0)
          .map((x, i) => i + 1);
      });
  }

  goToPage(currentPage: number) {
    this.currentPage = currentPage;
    this.requestsService
      .getPaginated(this.currentPage, this.itemsPerPage)
      .subscribe((res) => {
        this.consultationRequests = res.resultList;
        this.pagesArray = Array(res.totalPages)
          .fill(0)
          .map((x, i) => i + 1);
      });
  }
}
