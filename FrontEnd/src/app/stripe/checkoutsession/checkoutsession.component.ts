import { Dialog } from '@angular/cdk/dialog';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { CheckoutService } from 'src/app/checkout.service';
import { ServiceService } from 'src/app/service.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-checkoutsession',
  templateUrl: './checkoutsession.component.html',
  styleUrls: ['./checkoutsession.component.css']
})
export class CheckoutsessionComponent {
  // quantity!: number;
  // priceId!: string;

  // constructor(private checkoutService: CheckoutService) {}

  // onSubmit() {
  //   this.checkoutService.createCheckoutSession(this.quantity, this.priceId).subscribe(
  //     (response) => {
  //       // Handle the response from the API, e.g., redirect to the checkout URL.
  //       window.location.href = response.url;
  //     },
  //     (error) => {
  //       console.error('Error creating checkout session:', error);
  //       // Handle error as needed.
  //     }
  //   );
  // }
  checkForm!: FormGroup
  priceidform: any
  priceid: string = ''
  paymentlinkcreated: any;
  constructor(private fb: FormBuilder, private dialogdata: Dialog, private service: CheckoutService, private router: Router, private acroute: ActivatedRoute, private dialog: MatDialog) { }
  ngOnInit() {
    this.checkForm = this.fb.group({
      quantity: [],
      priceid: [this.priceidform]
    });
    this.priceidform = localStorage.getItem('priceid')
    console.log("this.priceidform", this.priceidform);



    this.checkForm.patchValue({
      prodid: this.priceidform
    })


    this.checkForm.patchValue({
      priceid: this.priceidform
    })

  }
  meassegSend(data: any) {
    if (this.checkForm.valid)
      this.service.createCheckoutSession(data).subscribe((res2: any) => {
        console.log(res2);

        this.paymentlinkcreated = res2.url;
        console.log("this.checkout", this.paymentlinkcreated);

        Swal.fire({
          icon: 'success',
          title: ' Upload',
          text: 'checkout session begins',
        }).then(() => {
          this.dialogdata.closeAll();
          window.location.href = this.paymentlinkcreated;
        });
      });


  }

}
