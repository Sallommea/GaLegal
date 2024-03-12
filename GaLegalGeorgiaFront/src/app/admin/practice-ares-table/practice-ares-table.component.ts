import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { PracticeArea } from 'src/app/models/practiceArea.model';
import { ModalService } from 'src/app/services/modal.service';
import { PracticeAreasService } from 'src/app/services/practice-areas.service';

@Component({
  selector: 'app-practice-ares-table',
  templateUrl: './practice-ares-table.component.html',
  styleUrls: ['./practice-ares-table.component.css'],
})
export class PracticeAresTableComponent {
  practiceAreas$: Observable<PracticeArea[]>;

  constructor(
    private modal: ModalService,
    private practiceAreaService: PracticeAreasService
  ) {}

  ngOnInit(): void {
    this.practiceAreas$ = this.practiceAreaService.getAllPracticeAreas();
  }

  addNew() {
    this.modal.toggleModal('addPracticeArea');
  }
}
