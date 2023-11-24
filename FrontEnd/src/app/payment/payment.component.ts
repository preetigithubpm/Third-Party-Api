import { ChangeDetectorRef, Component, Inject } from '@angular/core';
import { ApiService } from '../api.service';
import { Stripe } from '@stripe/stripe-js';
import { ActivatedRoute, Router } from '@angular/router';
import { Dialog } from '@angular/cdk/dialog';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ServiceService } from '../service.service';
import { MAT_DIALOG_DATA, MatDialog } from '@angular/material/dialog';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.css']
})
export class PaymentComponent {
  patientForm!: FormGroup
  stripePromise!: Promise<Stripe | null>;
  amount!:number;
  showForm: boolean = true; 
  clientSecret!: string | null;
  paymentHandler: any = null;
   show:boolean=false;
  success: boolean =false;
  failure: boolean =false;
  closeform:boolean=false;
  userId: any=0;

  constructor(private ServiceCall:ApiService,private routeL:Router,private dialogdata:Dialog,private fb: FormBuilder,
      private service: ServiceService, private acroute: ActivatedRoute,
       private dialog: MatDialog, @Inject(MAT_DIALOG_DATA) public data1: any,
       private cdRef: ChangeDetectorRef) { }

  ngOnInit() {

    this.patientForm = this.fb.group({
      payid: [],
      name: [''],
      email: ['',],
      address: ['',],
      number: ['', ],
      uid:[ this.userId],
      startDate: ['', ],
      endDate: ['', ],
    });

    this.userId=localStorage.getItem('userId')
    this.patientForm.patchValue({
      uid: this.userId
    })
    
    this.invokeStripe();
  }

  makePayment(amount: number) {
    const paymentHandler = (<any>window).StripeCheckout.configure({
      key: "pk_test_51NoJbgSHgVxrrED81ff2Joc7zRpffBmR3IarUpg8ipNfDwBq9IX4wRTjHlWRXQ82M5MrfQcs8AObqbGxcyxucgNG005WEaiA4X",
      locale: 'auto',
      token: (stripeToken: any) => {
        console.log("stripeToken",stripeToken);

        this.paymentStripe(stripeToken.id)
      }
    });


    paymentHandler.open({
      name: "PAYMENT ",
      description: "LIBRARY MANAGEMENT",
      amount: amount * 100,
 
    })
  }
  paymentStripe(tokenId: string) {
    this.ServiceCall.makePayment(tokenId).subscribe(
      (data: any) => {
        console.log("Data: ", data);
        if (data.data === "success") {
          this.success = true;
        } else {
          this.failure = true;
        }
      },
      (error: any) => {
        console.error("Error: ", error);
        this.failure = true;
      }
    );
  }

  invokeStripe() {
    if (!window.document.getElementById('stripe-script')) {
      const script = window.document.createElement('script');
      script.id = 'stripe-script';
      script.type = 'text/javascript';
      script.src = 'https://checkout.stripe.com/checkout.js';
      script.onload = () => {
        this.paymentHandler = (<any>window).StripeCheckout.configure({
          key: 'pk_test_51NoJbgSHgVxrrED81ff2Joc7zRpffBmR3IarUpg8ipNfDwBq9IX4wRTjHlWRXQ82M5MrfQcs8AObqbGxcyxucgNG005WEaiA4X',
          locale: 'auto',
          token: function (stripeToken: any) {
            console.log(stripeToken);
          },
        });
      };
      window.document.body.appendChild(script);
    }
  }
  getcompo(){
    this.dialogdata.closeAll();
  }
  submitdetail(data:any){
    console.log(data);
    this.service.addpay(data).subscribe((res:any)=>
    {
      if(res.responseCode==400){
        Swal.fire({
          icon: 'error',
          title: 'Invalid ',
          text: 'Please check your credentials and try again.',
        }).then(() => {
          location.reload();
        });
      }
      else{
        Swal.fire({
          icon: 'success',
          title: 'Details Added',
          text: 'order placed',
        }).then(() => {
          this.showForm = false;
          this.cdRef.detectChanges();
          this.show=true;
          this.closeform=true;

          this.routeL.navigate(['/get']);
        });
      }
    })
  }

}
