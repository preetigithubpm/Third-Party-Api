import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ServiceService } from '../service.service';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {
  signupForm!:FormGroup

  constructor(private service:ServiceService,private router:Router,private fb:FormBuilder){}
  ngOnInit(): void {
    this.signupForm=this.fb.group({
      name:['',Validators.required],
      password:['',Validators.required],
      email:['',Validators.required],
      roleId:['',Validators.required]
    })
  }
  signUpUser(data:any)
  {
    console.log(data);
    this.service.signUp(data).subscribe((res:any)=>
    {
      if(res.responseCode==400){
        Swal.fire({
          icon: 'error',
          title: 'Invalid ',
          text: 'Please check your credentials and try again.',
        }).then(() => {
          location.reload();
        });
      }
      else{
        Swal.fire({
          icon: 'success',
          title: 'User Added',
          text: 'You have successfully signin!',
        }).then(() => {
          this.router.navigate(['/verify']);
        });
      }
    })
  }



}
