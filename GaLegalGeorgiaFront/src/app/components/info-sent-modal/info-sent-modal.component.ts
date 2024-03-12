import { Component, EventEmitter, Output } from '@angular/core';
import { ModalService } from 'src/app/services/modal.service';
import { Router } from '@angular/router';
@Component({
  selector: 'app-info-sent-modal',
  templateUrl: './info-sent-modal.component.html',
  styleUrls: ['./info-sent-modal.component.css'],
})
export class InfoSentModalComponent {
  constructor(public modal: ModalService) {}

  ngOnInit(): void {
    this.modal.register('auth');
  }

  @Output() close = new EventEmitter();
  onCloseModal() {
    this.close.emit();
    this.modal.toggleModal('auth');
  }

  ngOnDestroy() {
    this.modal.unregister('auth');
  }
}
