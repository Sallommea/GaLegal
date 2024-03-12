import { Component, EventEmitter, Input, Output } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-card',
  standalone: true, //kaiaaa
  imports: [CommonModule],
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.css'],
})
export class CardComponent {
  scaleInCard: string = '';

  @Input() card: string | undefined;
  @Input() id: number | undefined;

  @Output() open = new EventEmitter();

  onCloseModal() {
    this.open.emit(this.id);
  }
}
