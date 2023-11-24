import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GetComponent } from './Patient/get/get.component';
import { AddeditComponent } from './addedit/addedit.component';
import { ViewComponent } from './view/view.component';
import { LoginComponent } from './login/login.component';
import { AuthGuard } from './auth.guard';
import { SignupComponent } from './signup/signup.component';
import { MailComponent } from './mail/mail.component';
import { ImageUploadComponent } from './image-upload/image-upload.component';
import { CameraUploadComponent } from './camera-upload/camera-upload.component';
import { ChartComponent } from './chart/chart.component';
import { ImageGridComponent } from './image-grid/image-grid.component';
import { PatientChartComponent } from './patient-chart/patient-chart.component';
import { PaymentComponent } from './payment/payment.component';
import { OtpVerificationComponent } from './otp-verification/otp-verification.component';
import { CartComponent } from './cart/cart.component';
import { CallComponent } from './call/call.component';
import { NestedDropdownComponent } from './nested-dropdown/nested-dropdown.component';
import { AatobagComponent } from './aatobag/aatobag.component';
import { AddProductComponent } from './add-product/add-product.component';
import { HeadComponent } from './compo/head/head.component';
import { CompoComponent } from './header/compo/compo.component';
import { VideoChatComponent } from './video-chat/video-chat.component';
import { EditorComponent } from './editor/editor.component';
import { CreateproductComponent } from './stripe/createproduct/createproduct.component';
import { PriceComponent } from './stripe/price/price.component';
import { PaylinkComponent } from './stripe/paylink/paylink.component';
import { CheckoutsessionComponent } from './stripe/checkoutsession/checkoutsession.component';
import { SessioncheckingComponent } from './sessionchecking/sessionchecking.component';
import { SuccessComponent } from './success/success.component';
import { SeesionupdateComponent } from './seesionupdate/seesionupdate.component';
import { CancelComponent } from './cancel/cancel.component';
import { NewpriceComponent } from './paymentsession/newprice/newprice.component';
import { NewsessionComponent } from './paymentsession/newsession/newsession.component';
import { NewProductComponent } from './paymentsession/new-product/new-product.component';
import { ProdComponent } from './compo/prod/prod.component';


const routes: Routes = [
 {path:'',component:LoginComponent},
 {path:'signup',component:SignupComponent},
  {path:'get',component:GetComponent,canActivate:[AuthGuard]},
  {path:'add',component:AddeditComponent,canActivate:[AuthGuard]},
  {path:'view',component:ViewComponent,canActivate:[AuthGuard]},
  {
    path:'mail',
    component:MailComponent
  },
  {
    path:'image',
    component:ImageUploadComponent
  },
  {
    path:'click',
    component:CameraUploadComponent
  },
  {
    path:'chart',
    component:ChartComponent
  },
  {
    path:'patientchart',
    component:PatientChartComponent
  },
  {
    path:'getimage',
    component:ImageGridComponent
  },
  {
    path:'new',
    component:PatientChartComponent
  },
  {
    path:'pay',
    component:PaymentComponent
  },
  {
    path:'verify',
    component:OtpVerificationComponent
  },
  {
    path:'cart',
    component:CallComponent
  },
  {
    path:'compo',
    component:CompoComponent
  },
  {
    path:'card',
    component:CartComponent
  },
  {
    path:'nest',
    component:NestedDropdownComponent
  }, {
    path:'bag',
    component:AatobagComponent
  }
  , {
    path:'store',
    component:AddProductComponent
  },
  {
    path:'head',
    component:HeadComponent
  },
  {
    path:'video',
    component:VideoChatComponent
  },
  {
    path:'com',
    component:CreateproductComponent
  },
  {
    path:'newproduct',
    component:NewProductComponent
  },
  {
    path:'editor',
    component:EditorComponent
  },
  {
    path:'price',
    component:PriceComponent
  },
  {
    path:'newprice',
    component:NewpriceComponent
  },
  {
    path:'link',
    component:PaylinkComponent
  },
  {
    path:'checkout',
    component:CheckoutsessionComponent
  }
  ,
  {
    path:'newcheckout',
    component:NewsessionComponent
  }
  
  , {
    path:'session',
    component:SessioncheckingComponent
  }
  ,
   {
    path:'success',
    component:SuccessComponent
  } 
  ,
  {
    path:'cancel',
    component:CancelComponent
  } ,
   {
    path:'final',
    component:SeesionupdateComponent
  },
  {
    path:'test',
    component:ProdComponent
  }



];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
