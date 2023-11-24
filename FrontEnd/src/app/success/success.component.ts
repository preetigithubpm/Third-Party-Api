import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { GetesssionComponent } from '../getesssion/getesssion.component';
import { MatDialog } from '@angular/material/dialog';
import { ServiceService } from '../service.service';
import { delay } from 'rxjs';

@Component({
  selector: 'app-success',
  templateUrl: './success.component.html',
  styleUrls: ['./success.component.css']
})
export class SuccessComponent {
  data:any;
  status:any;
  sessionid1:any;
  ispayment:boolean=false;
  iswaiting:boolean=true;
  message: string = "";
  constructor(private router: Router,private httpclient:HttpClient,private _dialog: MatDialog,
    private service:ServiceService) { }

  ngOnInit(): void {
    this.sessionid1=localStorage.getItem('sessionid');
    delay(5000);
    setInterval(() => {
      
      this.chexk();
    }, 2000);
  }

  chexk() {
    
    this.service.getstatus(this.sessionid1).subscribe((res:any)=>
    {
      console.log(res);
      console.log(res.responseMessage);
      this.data=res.responseMessage;
      if(this.data=='paid'){
        this.ispayment=true;this.iswaiting=false;
      }
      else if(this.data=='pending'){
        this.iswaiting=true;this.ispayment=false;
      }
      console.log(this.data);
    })
  }
  goBack() {
    // Navigate to the home page or the desired route
    this.router.navigate(['/get']);
  }
  gobyid(data:any){
   
    this._dialog.open(GetesssionComponent,{data})
  }
}