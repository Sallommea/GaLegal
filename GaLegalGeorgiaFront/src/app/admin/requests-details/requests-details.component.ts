import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import {
  ConsultationRequestDetails,
  UpdateStatus,
} from 'src/app/models/consultationRequest.model';
import { ConsultationRequestsService } from 'src/app/services/consultation-requests.service';

@Component({
  selector: 'app-requests-details',
  templateUrl: './requests-details.component.html',
  styleUrls: ['./requests-details.component.css'],
})
export class RequestsDetailsComponent implements OnInit {
  requestId: number;
  consultationRequestDetails$: Observable<ConsultationRequestDetails>;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private requestService: ConsultationRequestsService
  ) {}

  ngOnInit(): void {
    this.requestId = this.route.snapshot.params['id'];
    this.consultationRequestDetails$ = this.requestService.getRequestById(
      this.requestId
    );

    this.updateStatus();
  }

  updateStatus() {
    const status: UpdateStatus = {
      id: this.requestId,
      status: 'read',
    };
    this.requestService.updateStatus(this.requestId, status).subscribe();
  }

  deleteRequest() {
    this.requestService.deleteRequest(this.requestId).subscribe((res) => {
      this.router.navigate(['./admingalegal/home/requests']);
    });
  }
}
