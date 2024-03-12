import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-admin-login',
  templateUrl: './admin-login.component.html',
  styleUrls: ['./admin-login.component.css'],
})
export class AdminLoginComponent {
  isLoginMode = true;
  isLoading = false;
  error: string = null;
  credentials = {
    email: '',
    password: '',
  };

  constructor(private router: Router, private authService: AuthService) {}
  login(form: NgForm) {
    console.log(this.credentials);
    if (!form.valid) {
      return;
    }

    this.isLoading = true;

    this.authService.login(this.credentials).subscribe({
      next: (res) => {
        this.isLoading = false;
        this.router.navigate(['/admingalegal/home']);
      },
      error: (errorMessage) => {
        console.log(errorMessage);
        this.error = errorMessage;
        this.isLoading = false;
      },
    });

    form.reset();
  }
}
