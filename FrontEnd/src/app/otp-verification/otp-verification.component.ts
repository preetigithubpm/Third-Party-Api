import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ServiceService } from '../service.service';
import { Router } from '@angular/router';
import { TokenserviceService } from '../tokenservice.service';
import Swal from 'sweetalert2';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-otp-verification',
  templateUrl: './otp-verification.component.html',
  styleUrls: ['./otp-verification.component.css']
})
export class OtpVerificationComponent {
  otpForm!:FormGroup
  constructor(private fb:FormBuilder,private service:ServiceService,private router:Router)
  {}
ngOnInit()
{
  this.otpForm = this.fb.group({
    otp: ['', [Validators.required]]
 
  });
}
otpverify(data:any){
  debugger
  if(this.otpForm.valid)
    this.service.verifyOtp(data).subscribe((res:any)=>{
      Swal.fire({
        icon: 'success',
        title: ' Upload',
        text: 'Verified Successfully',
      }).then(() => {
        this.router.navigate(['']);

      });
      });
  }
}