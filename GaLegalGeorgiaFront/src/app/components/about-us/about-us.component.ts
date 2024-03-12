import { Component } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-about-us',
  templateUrl: './about-us.component.html',
  styleUrls: ['./about-us.component.css'],
})
export class AboutUsComponent {
  constructor(
    private translate: TranslateService,
    private titleService: Title
  ) {}
  ngOnInit(): void {
    this.translate.get('NAV.ABOUT').subscribe((title: string) => {
      this.titleService.setTitle(title);
    });
  }
}
