import { Dialog } from '@angular/cdk/dialog';
import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ServiceService } from '../service.service';
import { ActivatedRoute, Router } from '@angular/router';
import { MAT_DIALOG_DATA, MatDialog } from '@angular/material/dialog';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-send-message',
  templateUrl: './send-message.component.html',
  styleUrls: ['./send-message.component.css']
})
export class SendMessageComponent {
  messgeForm!:FormGroup
  constructor(private fb:FormBuilder,private dialogdata:Dialog,private service:ServiceService,private router:Router,private acroute:ActivatedRoute,private dialog:MatDialog,@Inject(MAT_DIALOG_DATA) public data1:any)
  {}
ngOnInit()
{
  this.messgeForm = this.fb.group({
    to: [''], 
    message: ['', Validators.required] 
  });
}
meassegSend(data:any){
  debugger
  if(this.messgeForm.valid)
    this.service.senadText(data).subscribe((res:any)=>{
      Swal.fire({
        icon: 'success',
        title: ' Upload',
        text: 'Messege Send SuccessFully',
      }).then(() => {
        this.dialogdata.closeAll();
        this.router.navigate(['/get']);

      });
      });
    
}
}
