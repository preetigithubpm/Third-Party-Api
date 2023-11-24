import { Dialog } from '@angular/cdk/dialog';
import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ServiceService } from '../service.service';
import { ActivatedRoute, Router } from '@angular/router';
import { MAT_DIALOG_DATA, MatDialog } from '@angular/material/dialog';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-sessionchecking',
  templateUrl: './sessionchecking.component.html',
  styleUrls: ['./sessionchecking.component.css']
})
export class SessioncheckingComponent {
  sessionForm!:FormGroup
  sessionid:string=""
  sessionlinkcreated: any;
  constructor(private fb:FormBuilder,private dialogdata:Dialog,private service:ServiceService,private router:Router,private acroute:ActivatedRoute,private dialog:MatDialog)
  {}
  
ngOnInit()
{
  this.sessionForm = this.fb.group({
    name: [''], 
    email: [''] ,
    amount: [], 
    quantity: [] ,
    productName: [''] 
  });

 
  
}
sessionSend(data:any){
  if(this.sessionForm.valid)
    this.service.sessioncreation(data).subscribe((res:any)=>{
      console.log("customersession",res);
  
     console.log("sessionid",this.sessionid);
     localStorage.setItem('sessionid',res.session.id)
     console.log("sessionid",this.sessionid);
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
