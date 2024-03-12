import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { MainPageComponent } from './components/main-page/main-page.component';
import { AboutUsComponent } from './components/about-us/about-us.component';
import { ContactUsComponent } from './components/contact-us/contact-us.component';
import { PracticeAreasComponent } from './components/practice-areas/practice-areas.component';
import { FormSubmittedComponent } from './components/form-submitted/form-submitted.component';
import { PageNotFoundComponent } from './components/page-not-found/page-not-found.component';

const routes: Routes = [
  {
    path: 'formsubmitted',
    component: FormSubmittedComponent,
  },
  {
    path: '',
    component: HomeComponent,
    children: [
      {
        path: 'admingalegal',
        loadChildren: () =>
          import('./admin/admin.module').then((m) => m.AdminModule),
      },
      { path: '', component: MainPageComponent },
      { path: 'about', component: AboutUsComponent },
      { path: 'contactus', component: ContactUsComponent },
      { path: 'practiceareas', component: PracticeAreasComponent },
    ],
  },
  {
    path: '**',
    component: PageNotFoundComponent,
  },
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, {
      initialNavigation: 'enabledBlocking',
      scrollPositionRestoration: 'top',
    }),
  ],
  exports: [RouterModule],
})
export class AppRoutingModule {}
