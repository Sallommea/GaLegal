import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminLoginComponent } from './admin-login/admin-login.component';
import { AdminHomeComponent } from './admin-home/admin-home.component';
import { PracticeAresTableComponent } from './practice-ares-table/practice-ares-table.component';
import { PracticeAreaDetailsComponent } from './practice-area-details/practice-area-details.component';
import { authGuard } from './auth.guard';
import { ConsultationRequestsComponent } from './consultation-requests/consultation-requests.component';
import { RequestsDetailsComponent } from './requests-details/requests-details.component';

const routes: Routes = [
  { path: '', component: AdminLoginComponent },
  {
    path: 'home',
    component: AdminHomeComponent,
    canActivate: [authGuard],
    children: [
      { path: '', component: PracticeAresTableComponent },
      { path: 'practicearea/:id', component: PracticeAreaDetailsComponent },
      {
        path: 'requests',
        component: ConsultationRequestsComponent,
      },
      {
        path: 'requests/consultationrequest/:id',
        component: RequestsDetailsComponent,
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AdminRoutingModule {}
