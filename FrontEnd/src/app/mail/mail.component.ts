import { Dialog } from '@angular/cdk/dialog';
import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ServiceService } from '../service.service';
import { ActivatedRoute, Router } from '@angular/router';
import { MAT_DIALOG_DATA, MatDialog } from '@angular/material/dialog';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-mail',
  templateUrl: './mail.component.html',
  styleUrls: ['./mail.component.css']
})
export class MailComponent {
  mailForm!:FormGroup
  constructor(private fb:FormBuilder,private dialogdata:Dialog,private service:ServiceService,private router:Router,private acroute:ActivatedRoute,private dialog:MatDialog,@Inject(MAT_DIALOG_DATA) public data1:any)
  {}
ngOnInit()
{
  this.mailForm = this.fb.group({
    toEmail: ['', [Validators.required, Validators.email,]], 
    subject: ['', [Validators.required]], 
    body: ['', Validators.required] 
  });
}
mailsend(data:any){
  debugger
  if(this.mailForm.valid)
    this.service.sendMail(data).subscribe((res:any)=>{
      Swal.fire({
        icon: 'success',
        title: ' Upload',
        text: 'mail Send SuccessFully',
      }).then(() => {
        this.dialogdata.closeAll();
        this.router.navigate(['/get']);

      });
      });
  }
}



