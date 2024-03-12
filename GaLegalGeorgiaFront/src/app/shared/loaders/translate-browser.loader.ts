import { Observable, of } from 'rxjs';
import { TranslateLoader } from '@ngx-translate/core';
import { en } from '../../../assets/i18n/en';
import { ge } from '../../../assets/i18n/ge';
export class TranslateServerLoader implements TranslateLoader {
  constructor() {}

  public getTranslation(lang: string): Observable<any> {
    return lang === 'en' ? of(en) : of(ge);
  }
}

export function translateServerLoaderFactory(): TranslateLoader {
  return new TranslateServerLoader();
}
