import { Dialog } from '@angular/cdk/dialog';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { ServiceService } from 'src/app/service.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-price',
  templateUrl: './price.component.html',
  styleUrls: ['./price.component.css']
})
export class PriceComponent {
  priceForm!:FormGroup
  productidform:any
  priceid:string=''
  constructor(private fb:FormBuilder,private dialogdata:Dialog,private service:ServiceService,private router:Router,private acroute:ActivatedRoute,private dialog:MatDialog)
  {}
ngOnInit()
{
  this.priceForm = this.fb.group({
    amount: [], 
    interval: [''], 
    prodid: [this.productidform] 
  });
  this.productidform=localStorage.getItem('productid')
  
  
  this.priceForm.patchValue({
    prodid: this.productidform
  })

}
meassegSend(data:any){
  if(this.priceForm.valid)
    this.service.senadPrice(data).subscribe((res1:any)=>{
      localStorage.setItem('priceid',res1.id)
      Swal.fire({
        icon: 'success',
        title: ' Upload',
        text: 'Price Added SuccessFully',
      }).then(() => {
        this.dialogdata.closeAll();
        this.router.navigate(['/checkout']);
                    });
      });
    
}
}
