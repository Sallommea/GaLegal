import { Injectable } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { AuthRequest } from '../models/auth.model';
import { map, catchError } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  constructor(
    private http: HttpClient,
    private router: Router,
    private cookieService: CookieService
  ) {}
  token: string;
  errorText: string;

  isLoggedIn() {
    const isLoggedIn = this.cookieService.get('token');

    return !!isLoggedIn;
  }
  login(request: AuthRequest) {
    return this.http
      .post(`${environment.webApi}api/Auth`, request, { responseType: 'text' })
      .pipe(
        map((token: string) => {
          this.token = token;
          this.cookieService.set('token', token, {
            secure: true,
          });

          return token;
        }),
        catchError((err) => {
          try {
            this.errorText = JSON.parse(err.error).title;
          } catch (error) {
            this.errorText = err;
          }

          let errorTitle =
            this.errorText === 'Invalid Data'
              ? 'Invalid Data'
              : 'An unknown error occurred!';

          console.error('Login error:', errorTitle);
          throw errorTitle;
        })
      );
  }

  logout() {
    this.cookieService.delete('token', '/', null, true);
    this.router.navigateByUrl('/');
  }
}
