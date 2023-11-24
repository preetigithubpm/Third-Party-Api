import { Dialog } from '@angular/cdk/dialog';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { ServiceService } from 'src/app/service.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-new-product',
  templateUrl: './new-product.component.html',
  styleUrls: ['./new-product.component.css']
})
export class NewProductComponent {
  localstoreres:any
  prodForm!:FormGroup
  productid:string=''
  constructor(private fb:FormBuilder,private dialogdata:Dialog,private service:ServiceService,private router:Router,private acroute:ActivatedRoute,private dialog:MatDialog)
  {}
ngOnInit()
{
  this.prodForm = this.fb.group({
    name: ['', Validators.required] 
  });
}
Send(data:any){
  if(this.prodForm.valid)
    this.service.addProd(data).subscribe((res:any)=>{
  console.log(res);
  console.log(res.id);
  localStorage.setItem('productid',res.id)
  
  console.log(this.productid);
  
  
  
       this.localstoreres=res;
      Swal.fire({
        icon: 'success',
        title: ' Upload',
        text: 'Product Added SuccessFully',
      }).then(() => {
        this.dialogdata.closeAll();
        this.router.navigate(['/newprice']);

      });
      });
    
}
}
