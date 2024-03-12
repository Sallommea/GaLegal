import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormControl, FormsModule, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-input',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, FormsModule],
  templateUrl: './input.component.html',
  styleUrls: ['./input.component.css'],
})
export class InputComponent {
  @Input() control: FormControl = new FormControl();
  @Input() placeholder: string = '';
  @Input() isSubmitAttempted: boolean = false;
  @Input() type: string = 'text';
  @Input() isNumber: boolean = false;
  @Input() maxlength;

  hasInputErrors() {}
}
