import { Dialog } from '@angular/cdk/dialog';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { ServiceService } from 'src/app/service.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-paylink',
  templateUrl: './paylink.component.html',
  styleUrls: ['./paylink.component.css']
})
export class PaylinkComponent {
  paylinkForm!: FormGroup
  priceidform: any
  priceid: string = ''
  paymentlinkcreated: any;
  constructor(private fb: FormBuilder, private dialogdata: Dialog, private service: ServiceService, private router: Router, private acroute: ActivatedRoute, private dialog: MatDialog) { }
  ngOnInit() {
    this.paylinkForm = this.fb.group({
      quantity: [],
      priceid: [this.priceidform]
    });
    this.priceidform = localStorage.getItem('priceid')
    console.log("this.priceidform", this.priceidform);



    this.paylinkForm.patchValue({
      prodid: this.priceidform
    })


    this.paylinkForm.patchValue({
      priceid: this.priceidform
    })

  }
  meassegSend(data: any) {
    if (this.paylinkForm.valid)
      this.service.sendpaylink(data).subscribe((res2: any) => {
        console.log(res2);

        this.paymentlinkcreated = res2.url;
        console.log("this.paymentlinkcreated", this.paymentlinkcreated);

        Swal.fire({
          icon: 'success',
          title: ' Upload',
          text: 'Payment Link Created',
        }).then(() => {
          this.dialogdata.closeAll();
          window.location.href = this.paymentlinkcreated;
        });
      });


  }
}
