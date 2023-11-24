import { Dialog } from '@angular/cdk/dialog';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ServiceService } from '../service.service';
import { Router } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-seesionupdate',
  templateUrl: './seesionupdate.component.html',
  styleUrls: ['./seesionupdate.component.css']
})
export class SeesionupdateComponent {
  sessionCustomerForm!:FormGroup
  sessionlinkcreated: any;
  constructor(private fb:FormBuilder,private dialogdata:Dialog,private service:ServiceService,private router:Router,private dialog:MatDialog)
  {}
ngOnInit()
{
  this.sessionCustomerForm = this.fb.group({
    customerId: [''], 
    name: [''] ,
    email: [], 
    quantity: [] ,
    priceid: [''] 
  });
}
sessionSend(data:any){
  debugger
  if(this.sessionCustomerForm.valid)
    this.service.sessionCustomwercreation(data).subscribe((res:any)=>{
      console.log("res",res);
      this.sessionlinkcreated = res.session.url;
      console.log("sessionlinkcreated", this.sessionlinkcreated);
      Swal.fire({
        icon: 'success',
        title: ' Upload',
        text: 'Redirecting to Payment',
      }).then(() => {
        this.dialogdata.closeAll();
          window.location.href = this.sessionlinkcreated;
      });
      });
    
}
}
