import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable, Subscription } from 'rxjs';
import {
  PracticeAreaDetails,
  PracticeAreaUpdate,
} from 'src/app/models/practiceArea.model';
import { PracticeAreasService } from 'src/app/services/practice-areas.service';

@Component({
  selector: 'app-practice-area-details',
  templateUrl: './practice-area-details.component.html',
  styleUrls: ['./practice-area-details.component.css'],
})
export class PracticeAreaDetailsComponent implements OnInit, OnDestroy {
  practiceAreaId: number;
  practiceAreaDetailss$: Observable<PracticeAreaDetails>;
  content: [];
  showForm = false;
  subs: Subscription[] = [];
  lang: string;
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private practiceAreaService: PracticeAreasService
  ) {}

  ngOnInit(): void {
    this.practiceAreaId = this.route.snapshot.params['id'];
    this.practiceAreaDetailss$ = this.practiceAreaService.getPracticeAreaByID(
      this.practiceAreaId
    );
  }

  deletePracticeArea() {
    this.subs.push(
      this.practiceAreaService
        .deletePracticeArea(this.practiceAreaId)
        .subscribe((res) => {
          this.router.navigate(['./admingalegal/home']);
        })
    );
  }

  practiceAreaForm = new FormGroup({
    id: new FormControl(''),
    title: new FormControl('', [Validators.required, Validators.maxLength(70)]),
    content: new FormControl('', [Validators.required]),
    titleEn: new FormControl('', [
      Validators.required,
      Validators.maxLength(70),
    ]),
    contentEn: new FormControl('', [Validators.required]),
  });

  showUpdateForm() {
    this.showForm = !this.showForm;
  }

  onSubmit() {
    if (this.practiceAreaForm.invalid) {
      return;
    }
    const practiceAreaUpdated: PracticeAreaUpdate = {
      id: +this.practiceAreaId,
      title: this.practiceAreaForm.value.title,
      content: this.practiceAreaForm.value.content,
      titleEn: this.practiceAreaForm.value.titleEn,
      contentEn: this.practiceAreaForm.value.contentEn,
    };

    this.subs.push(
      this.practiceAreaService
        .updatePracticeArea(this.practiceAreaId, practiceAreaUpdated)
        .subscribe((res) => {
          this.practiceAreaDetailss$ =
            this.practiceAreaService.getPracticeAreaByID(this.practiceAreaId);
        })
    );
    this.showForm = !this.showForm;
  }

  ngOnDestroy(): void {
    this.subs.forEach((x) => x.unsubscribe());
  }
}
