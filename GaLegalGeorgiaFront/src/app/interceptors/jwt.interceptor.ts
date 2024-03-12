import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { AuthService } from '../services/auth.service';
import { CookieService } from 'ngx-cookie-service';
import { environment } from 'src/environments/environment';
@Injectable()
export class JwtInterceptor implements HttpInterceptor {
  constructor(
    private auth: AuthService,
    private cookieService: CookieService
  ) {}
  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    const api = environment.webApi;
    const isApiUrl = req.url.startsWith(api);

    if (this.auth.isLoggedIn() && isApiUrl) {
      req = req.clone({
        setHeaders: {
          Authorization: `Bearer ${this.cookieService.get('token')}`,
        },
      });
    }

    return next.handle(req);
  }
}
