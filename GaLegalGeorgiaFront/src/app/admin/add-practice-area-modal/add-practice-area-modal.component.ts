import { Component, EventEmitter, OnDestroy, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Subscription } from 'rxjs';
import { PracticeAreaPost } from 'src/app/models/practiceArea.model';
import { ModalService } from 'src/app/services/modal.service';
import { PracticeAreasService } from 'src/app/services/practice-areas.service';

@Component({
  selector: 'app-add-practice-area-modal',
  templateUrl: './add-practice-area-modal.component.html',
  styleUrls: ['./add-practice-area-modal.component.css'],
})
export class AddPracticeAreaModalComponent implements OnDestroy {
  @Output() close = new EventEmitter();
  subs: Subscription[] = [];

  constructor(
    public modal: ModalService,
    private practiceAreaService: PracticeAreasService
  ) {}

  practiceAreaForm = new FormGroup({
    title: new FormControl('', [Validators.required, Validators.maxLength(70)]),
    content: new FormControl('', [Validators.required]),
    titleEn: new FormControl('', [
      Validators.required,
      Validators.maxLength(70),
    ]),
    contentEn: new FormControl('', [Validators.required]),
  });

  ngOnInit(): void {
    this.modal.register('addPracticeArea');
  }

  onSubmit() {
    if (this.practiceAreaForm.invalid) {
      return;
    }
    const practiceAreaInfo: PracticeAreaPost = {
      title: this.practiceAreaForm.value.title,
      content: this.practiceAreaForm.value.content,
      titleEn: this.practiceAreaForm.value.titleEn,
      contentEn: this.practiceAreaForm.value.contentEn,
    };
    this.subs.push(
      this.practiceAreaService
        .addPracticeArea(practiceAreaInfo)
        .subscribe((res) => {
          this.close.emit();
          this.modal.toggleModal('addPracticeArea');
          window.location.reload();
        })
    );
  }

  ngOnDestroy() {
    this.modal.unregister('addPracticeArea');
  }
}
