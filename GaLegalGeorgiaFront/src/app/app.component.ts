import { Component, OnInit } from '@angular/core';
import { Meta, Title } from '@angular/platform-browser';
import { TranslateService } from '@ngx-translate/core';
import { SsrCookieService } from 'ngx-cookie-service-ssr';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  lang: any;

  constructor(
    private cookieService: SsrCookieService,
    private translate: TranslateService,
    private titleService: Title,
    private metaService: Meta
  ) {}

  ngOnInit(): void {
    this.lang = this.cookieService.get('lang');
    this.translate.use(this.lang);
    this.translate.get('META.TITLE').subscribe((title: string) => {
      this.titleService.setTitle(title);
    });

    // Set dynamic meta description
    this.translate.get('META.DESCRIPTION').subscribe((description: string) => {
      this.metaService.updateTag({ name: 'description', content: description });
    });
  }
}
