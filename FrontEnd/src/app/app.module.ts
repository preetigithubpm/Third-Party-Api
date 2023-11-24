import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatIconModule} from '@angular/material/icon';
import {MatButtonModule} from '@angular/material/button';
import {MatDialogModule} from '@angular/material/dialog';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import {MatDatepickerModule} from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import {MatRadioModule} from '@angular/material/radio';
import {MatSelectModule} from '@angular/material/select';
import {MatTableModule} from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { GetComponent } from './Patient/get/get.component';
import { AddeditComponent } from './addedit/addedit.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {FormsModule,ReactiveFormsModule} from '@angular/forms'
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { ViewComponent } from './view/view.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import {MatMenuModule} from '@angular/material/menu';
import { LoginComponent } from './login/login.component';
import { InterceptorInterceptor } from './interceptor.interceptor';
import { SignupComponent } from './signup/signup.component';
import { MailComponent } from './mail/mail.component';
import { SendMessageComponent } from './send-message/send-message.component';
import { ImageUploadComponent } from './image-upload/image-upload.component';
import { CameraUploadComponent } from './camera-upload/camera-upload.component';

import { NgChartsModule } from 'ng2-charts';


import { ChartComponent } from './chart/chart.component';

import { ImageGridComponent } from './image-grid/image-grid.component';
import { DxChartModule } from 'devextreme-angular';
import { PatientChartComponent } from './patient-chart/patient-chart.component';
import { PaymentComponent } from './payment/payment.component';
import { OtpVerificationComponent } from './otp-verification/otp-verification.component';
import { CartComponent } from './cart/cart.component';
import { CallComponent } from './call/call.component';
import { AddImageComponent } from './add-image/add-image.component';
import { GetbyidiamgeComponent } from './getbyidiamge/getbyidiamge.component';
import { GetbyPateintImageComponent } from './getby-pateint-image/getby-pateint-image.component';
import { NestedDropdownComponent } from './nested-dropdown/nested-dropdown.component';
import { DocallComponent } from './docall/docall.component';
import { AatobagComponent } from './aatobag/aatobag.component';
import { AddProductComponent } from './add-product/add-product.component';

import { CompoComponent } from './header/compo/compo.component';
import { HeadComponent } from './compo/head/head.component';
import { WishComponent } from './compo/wish/wish.component';
import { ProdComponent } from './compo/prod/prod.component';
import { DataService } from './data.service';
import { FilterPipe } from './FilterPipe';
import { VideoChatComponent } from './video-chat/video-chat.component';
import { MatGridListModule } from '@angular/material/grid-list';
import { EditorComponent } from './editor/editor.component';
import { AngularEditorModule } from '@kolkov/angular-editor';
import { CreateproductComponent } from './stripe/createproduct/createproduct.component';
import { PriceComponent } from './stripe/price/price.component';
import { PaylinkComponent } from './stripe/paylink/paylink.component';
import { CheckoutsessionComponent } from './stripe/checkoutsession/checkoutsession.component';
import { SessioncheckingComponent } from './sessionchecking/sessionchecking.component';
import { GetesssionComponent } from './getesssion/getesssion.component';
import { SuccessComponent } from './success/success.component';
import { SeesionupdateComponent } from './seesionupdate/seesionupdate.component';
import { CancelComponent } from './cancel/cancel.component';
import { NewProductComponent } from './paymentsession/new-product/new-product.component';
import { NewpriceComponent } from './paymentsession/newprice/newprice.component';
import { NewsessionComponent } from './paymentsession/newsession/newsession.component';
import { AdvanceSearchPipe } from './advance-search.pipe';
import { ServiceService } from './service.service';







@NgModule({
  declarations: [
    AppComponent,
    GetComponent,
    AddeditComponent,
    ViewComponent,
    DashboardComponent,
    LoginComponent,
    SignupComponent,
    MailComponent,
    SendMessageComponent,
    ImageUploadComponent,
    CameraUploadComponent,
    ChartComponent,
    ImageGridComponent,
    PatientChartComponent,
    PaymentComponent,
    OtpVerificationComponent,
    CartComponent,
    CallComponent,
    AddImageComponent,
    FilterPipe,
    GetbyidiamgeComponent,
    GetbyPateintImageComponent,
    NestedDropdownComponent,
    DocallComponent,
    AatobagComponent,
    AddProductComponent,
    CompoComponent,
    HeadComponent,
    WishComponent,
    ProdComponent,
    VideoChatComponent,
    EditorComponent,
    CreateproductComponent,
    PriceComponent,
    PaylinkComponent,
    CheckoutsessionComponent,
    SessioncheckingComponent,
    GetesssionComponent,
    SuccessComponent,
    SeesionupdateComponent,
    CancelComponent,
    NewProductComponent,
    NewpriceComponent,
    NewsessionComponent,
    AdvanceSearchPipe

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatIconModule,
    MatButtonModule,
    MatDialogModule,
    MatFormFieldModule,
    MatInputModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatRadioModule,
    MatPaginatorModule,
    MatSortModule,
    MatTableModule,
    MatSelectModule,
    FormsModule,ReactiveFormsModule,
    HttpClientModule,
    MatMenuModule,
    NgChartsModule,DxChartModule,
    MatGridListModule,
    AngularEditorModule,
    
    

  ],
  providers: [
    {provide: HTTP_INTERCEPTORS,
      useClass: InterceptorInterceptor,
      multi: true,},DataService,
      [ServiceService]
  ],
  
  bootstrap: [AppComponent]
})
export class AppModule { }
