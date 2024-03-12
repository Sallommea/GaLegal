import { Component, Input } from '@angular/core';
import { Router } from '@angular/router';

import { ModalService } from 'src/app/services/modal.service';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css'],
})
export class DetailsComponent {
  constructor(public modal: ModalService, private router: Router) {}
  @Input() description: [] | undefined;
  @Input() title: string;

  ngOnInit(): void {
    this.modal.register('details');
  }
  ngOnDestroy() {
    this.modal.unregister('details');
  }
}
