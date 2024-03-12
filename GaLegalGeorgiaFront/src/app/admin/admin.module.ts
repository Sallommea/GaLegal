import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminRoutingModule } from './admin-routing.module';
import { AdminLoginComponent } from './admin-login/admin-login.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AdminHomeComponent } from './admin-home/admin-home.component';
import { PracticeAresTableComponent } from './practice-ares-table/practice-ares-table.component';
import { PracticeAreaDetailsComponent } from './practice-area-details/practice-area-details.component';
import { AddPracticeAreaModalComponent } from './add-practice-area-modal/add-practice-area-modal.component';
import { ModalComponent } from '../shared/modal/modal.component';
import { LoadingSpinnerComponent } from '../shared/loading-spinner/loading-spinner.component';
import { ConsultationRequestsComponent } from './consultation-requests/consultation-requests.component';
import { RequestsDetailsComponent } from './requests-details/requests-details.component';
import { TranslateModule } from '@ngx-translate/core';

@NgModule({
  declarations: [
    AdminLoginComponent,
    AdminHomeComponent,
    PracticeAresTableComponent,
    PracticeAreaDetailsComponent,
    AddPracticeAreaModalComponent,
    ConsultationRequestsComponent,
    RequestsDetailsComponent,
  ],
  imports: [
    CommonModule,
    LoadingSpinnerComponent,
    AdminRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    ModalComponent,
    TranslateModule,
  ],
  exports: [],
})
export class AdminModule {}
