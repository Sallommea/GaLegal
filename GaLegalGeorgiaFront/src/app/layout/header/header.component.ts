import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { SsrCookieService } from 'ngx-cookie-service-ssr';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
})
export class HeaderComponent implements OnInit {
  lang: any;
  isEnglish = false;
  navVariable: boolean = false;
  constructor(
    private cookieService: SsrCookieService,
    public translate: TranslateService
  ) {
    this.isEnglish = translate.currentLang == 'en';
  }
  ngOnInit(): void {
    this.lang = this.cookieService.get('lang');
    if (this.lang) {
      this.translate.use(this.lang);
    }
  }
  public changeLanguage(e: any) {
    const lang = e.target.value;
    this.cookieService.set('lang', lang, null, '/', null, true, 'None');
    window.location.reload();
  }

  openNav() {
    this.navVariable = !this.navVariable;
  }
}
