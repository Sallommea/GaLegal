import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router, RouterLink } from '@angular/router';

@Component({
  selector: 'app-button',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './button.component.html',
  styleUrls: ['./button.component.css'],
})
export class ButtonComponent {
  @Input() type = 'button';
  showbutton: string = '';

  constructor(private router: Router) {}

  onContactUs() {
    if (this.type === 'button') {
      this.router.navigate(['/contactus']);
    }
  }
}
