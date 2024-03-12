import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {
  PracticeArea,
  PracticeAreaDetails,
  PracticeAreaPost,
  PracticeAreaUpdate,
} from '../models/practiceArea.model';
import { SsrCookieService } from 'ngx-cookie-service-ssr';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class PracticeAreasService {
  lang: string;

  constructor(
    private http: HttpClient,
    private cookieService: SsrCookieService
  ) {
    this.lang = this.cookieService.get('lang') == 'en' ? 'en' : 'ge';
  }

  getAllPracticeAreas(): Observable<PracticeArea[]> {
    return this.http.get<PracticeArea[]>(
      `${environment.webApi}api/PracticeAreas?lang=${this.lang}`
    );
  }

  getPracticeAreaByID(id: number): Observable<PracticeAreaDetails> {
    return this.http.get<PracticeAreaDetails>(
      `${environment.webApi}api/PracticeAreas/${id}?languageCookie=${this.lang}`
    );
  }

  addPracticeArea(practiceArea: PracticeAreaPost) {
    return this.http.post<PracticeAreaPost>(
      `${environment.webApi}api/PracticeAreas`,
      practiceArea
    );
  }

  deletePracticeArea(id) {
    return this.http.delete(`${environment.webApi}api/PracticeAreas/${id}`);
  }

  updatePracticeArea(id: number, practiceArea: PracticeAreaUpdate) {
    return this.http.put<PracticeAreaUpdate>(
      `${environment.webApi}api/PracticeAreas/${id}`,
      practiceArea
    );
  }
}
