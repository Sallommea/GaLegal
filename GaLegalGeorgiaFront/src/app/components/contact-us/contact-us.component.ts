import { Component, OnDestroy } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Title } from '@angular/platform-browser';
import { Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { Subscription } from 'rxjs';
import { ConsultationRequest } from 'src/app/models/consultationRequest.model';
import { ConsultationRequestsService } from 'src/app/services/consultation-requests.service';
import { ModalService } from 'src/app/services/modal.service';

@Component({
  selector: 'app-contact-us',
  templateUrl: './contact-us.component.html',
  styleUrls: ['./contact-us.component.css'],
})
export class ContactUsComponent implements OnDestroy {
  isSubmitted: boolean = false;
  showModal: boolean = false;
  subs: Subscription[] = [];

  contactForm = new FormGroup({
    firstName: new FormControl('', [
      Validators.required,
      Validators.minLength(2),
      Validators.maxLength(50),
    ]),
    lastName: new FormControl('', [
      Validators.required,
      Validators.minLength(2),
      Validators.maxLength(50),
    ]),
    email: new FormControl('', [
      Validators.required,
      Validators.minLength(5),
      Validators.maxLength(50),
      Validators.email,
    ]),
    phoneNumber: new FormControl('', [
      Validators.required,
      Validators.minLength(9),
      Validators.maxLength(13),
      this.correctNumber,
    ]),
    company: new FormControl(),
    description: new FormControl(),
  });

  constructor(
    private router: Router,
    public modal: ModalService,
    private consultationRequestsService: ConsultationRequestsService,
    private translate: TranslateService,
    private titleService: Title
  ) {}

  ngOnInit(): void {
    this.translate.get('NAV.CONTACT').subscribe((title: string) => {
      this.titleService.setTitle(title);
    });
  }

  correctNumber(control: FormControl) {
    const regex = new RegExp('^[0-9+]+$');
    if (control.value != null && !regex.test(control.value)) {
      return { correctNumber: true };
    }
    return null;
  }

  onSubmit($event: Event) {

    this.isSubmitted = true;

    if (this.contactForm.invalid) {
      return;
    }

    const formAllInfo: ConsultationRequest = {
      firstName: this.contactForm.value.firstName,
      lastName: this.contactForm.value.lastName,
      phoneNumber: this.contactForm.value.phoneNumber,
      email: this.contactForm.value.email,
      company: this.contactForm.value.company,
      description: this.contactForm.value.description,
      messageStatus: 'new',
    };

    this.subs.push(
      this.consultationRequestsService
        .addConsultationRequest(formAllInfo)
        .subscribe((res) => {})
    );
    this.modal.toggleModal('auth');
  }

  closeModal() {
    this.showModal = !this.showModal;
    setTimeout(() => {
      this.router.navigate(['./']);
    });
  }
  ngOnDestroy(): void {
    this.subs.forEach((x) => x.unsubscribe());
  }
}
