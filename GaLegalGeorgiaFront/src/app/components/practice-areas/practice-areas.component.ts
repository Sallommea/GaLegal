import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { TranslateService } from '@ngx-translate/core';
import { SsrCookieService } from 'ngx-cookie-service-ssr';
import { Observable } from 'rxjs';
import {
  PracticeArea,
  PracticeAreaDetails,
} from 'src/app/models/practiceArea.model';
import { ModalService } from 'src/app/services/modal.service';
import { PracticeAreasService } from 'src/app/services/practice-areas.service';

@Component({
  selector: 'app-practice-areas',
  templateUrl: './practice-areas.component.html',
  styleUrls: ['./practice-areas.component.css'],
})
export class PracticeAreasComponent implements OnInit {
  receivedData: number;
  foundItem: [];
  title: string;
  practiceAreas$: Observable<PracticeArea[]>;
  foundItem$: Observable<PracticeAreaDetails>;
  lang: string;
  constructor(
    public modal: ModalService,
    private practiceAreaService: PracticeAreasService,
    private translate: TranslateService,
    private titleService: Title
  ) {}

  ngOnInit(): void {
    this.practiceAreas$ = this.practiceAreaService.getAllPracticeAreas();
    this.translate.get('NAV.PRACTICEAREAS').subscribe((title: string) => {
      this.titleService.setTitle(title);
    });
  }

  openModal(data: number) {
    this.receivedData = data;
    this.foundItem$ = this.practiceAreaService.getPracticeAreaByID(data);
    this.modal.toggleModal('details');
  }
}
