import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {
  ConsultationRequest,
  ConsultationRequestDetails,
  PaginatedRequests,
  UpdateStatus,
} from '../models/consultationRequest.model';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class ConsultationRequestsService {
  constructor(private http: HttpClient) {}

  addConsultationRequest(consultationRequest: ConsultationRequest) {
    return this.http.post<ConsultationRequest>(
      `${environment.webApi}api/ConsultationRequests/create`,
      consultationRequest
    );
  }

  getPaginated(
    pageNumber: number,
    itemsPerPage: number
  ): Observable<PaginatedRequests> {
    return this.http.get<PaginatedRequests>(
      `${environment.webApi}api/ConsultationRequests/get-paginated/${pageNumber}/${itemsPerPage}`
    );
  }

  getRequestById(id: number): Observable<ConsultationRequestDetails> {
    return this.http.get<ConsultationRequestDetails>(
      `${environment.webApi}api/ConsultationRequests/${id}`
    );
  }

  updateStatus(id: number, status: UpdateStatus) {
    return this.http.patch<UpdateStatus>(
      `${environment.webApi}api/ConsultationRequests/${id}`,
      status
    );
  }
  deleteRequest(id) {
    return this.http.delete(
      `${environment.webApi}api/ConsultationRequests/${id}`
    );
  }
}
