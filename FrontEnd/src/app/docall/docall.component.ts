import { Dialog } from '@angular/cdk/dialog';
import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import Swal from 'sweetalert2';
import { ServiceService } from '../service.service';
import { ActivatedRoute, Router } from '@angular/router';
import { MAT_DIALOG_DATA, MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-docall',
  templateUrl: './docall.component.html',
  styleUrls: ['./docall.component.css']
})
export class DocallComponent {
  messgeForm!:FormGroup
  callValue: any;
  newPhone: any;
  constructor(private fb:FormBuilder,private dialogdata:Dialog,private service:ServiceService,private router:Router,private acroute:ActivatedRoute,private dialog:MatDialog,@Inject(MAT_DIALOG_DATA) public data1:any)
  {}
ngOnInit()
{
  this.messgeForm = this.fb.group({
    to: [''], 
  });
}
number:any;
meassegSend(data:any){
  debugger
  this.number=data.to;
  //this.newPhone = data.trim(/\+/g, '');
  //console.log('this.newPhone: ',this.newPhone);
  this.service.getCall(this.number).subscribe((res:any)=>{
    this.callValue=res;
    Swal.fire({
      icon: 'success',
      title: ' Calling',
      text: 'Redirecting to call',
    }).then(() => {

    });
  })
}
}
