import { Dialog } from '@angular/cdk/dialog';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { ServiceService } from 'src/app/service.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-newsession',
  templateUrl: './newsession.component.html',
  styleUrls: ['./newsession.component.css']
})
export class NewsessionComponent {
  sessionForm!:FormGroup
  sessionid:string=""
  priceidform:any
  sessionlinkcreated: any;
  constructor(private fb:FormBuilder,private dialogdata:Dialog,private service:ServiceService,private router:Router,private acroute:ActivatedRoute,private dialog:MatDialog)
  {}
  
ngOnInit()
{
  this.sessionForm = this.fb.group({
    customerId: [''], 
    name: [''], 
    email: [''] ,
    quantity: [], 
    priceid: [this.priceidform] 
  });

  this.priceidform=localStorage.getItem('priceid')
  console.log(this.priceidform);
  this.sessionForm.patchValue({
    priceid: this.priceidform
  })
}
sessionSend(data:any){
  if(this.sessionForm.valid)
  debugger
    this.service.sessionCustomwercreation(data).subscribe((res:any)=>{
      console.log("res",res);
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
