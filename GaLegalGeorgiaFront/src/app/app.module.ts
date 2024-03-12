import { NgModule, PLATFORM_ID } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { provideClientHydration } from '@angular/platform-browser';
import { TransferHttpCacheModule } from '@nguniversal/common';
import { translateServerLoaderFactory } from './shared/loaders/translate-browser.loader';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { TranslateLoader, TranslateModule } from '@ngx-translate/core';
import {
  HTTP_INTERCEPTORS,
  HttpClient,
  HttpClientModule,
} from '@angular/common/http';
import { HeaderComponent } from './layout/header/header.component';
import { FooterComponent } from './layout/footer/footer.component';
import { MainPageComponent } from './components/main-page/main-page.component';
import { CardComponent } from './shared/card/card.component';
import { InputComponent } from './shared/input/input.component';
import { ReactiveFormsModule } from '@angular/forms';
import { ButtonComponent } from './shared/button/button.component';
import { AboutUsComponent } from './components/about-us/about-us.component';
import { ContactUsComponent } from './components/contact-us/contact-us.component';
import { PracticeAreasComponent } from './components/practice-areas/practice-areas.component';
import { InfoSentModalComponent } from './components/info-sent-modal/info-sent-modal.component';
import { ModalComponent } from './shared/modal/modal.component';
import { DetailsComponent } from './components/details/details.component';
import { FormSubmittedComponent } from './components/form-submitted/form-submitted.component';
import { JwtInterceptor } from './interceptors/jwt.interceptor';
import { LoadingSpinnerComponent } from './shared/loading-spinner/loading-spinner.component';
import { PageNotFoundComponent } from './components/page-not-found/page-not-found.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    HeaderComponent,
    MainPageComponent,
    AboutUsComponent,
    ContactUsComponent,
    PracticeAreasComponent,
    InfoSentModalComponent,
    DetailsComponent,
    FormSubmittedComponent,
    FooterComponent,
    PageNotFoundComponent,
  ],
  imports: [
    CardComponent,
    InputComponent,
    ButtonComponent,
    ModalComponent,
    LoadingSpinnerComponent,
    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
        useFactory: translateServerLoaderFactory,
        deps: [HttpClient, PLATFORM_ID],
      },
      defaultLanguage: 'ge',
    }),
    TransferHttpCacheModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
  ],
  providers: [
    provideClientHydration(),
    {
      provide: HTTP_INTERCEPTORS,
      useClass: JwtInterceptor,
      multi: true,
    },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
