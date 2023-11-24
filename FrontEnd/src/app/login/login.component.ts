import { Component, OnInit } from '@angular/core';
import { ServiceService } from '../service.service';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import Swal from 'sweetalert2';
import { TokenserviceService } from '../tokenservice.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
 loginForm!:FormGroup
  constructor(private service:ServiceService,private router:Router,private fb:FormBuilder,private tokenservice:TokenserviceService)
  {
    
  }
  ngOnInit(): void {
    this.loginForm=this.fb.group({
      name:['',[Validators.required,this.nameValidator.bind(this)]],
      password:['',[Validators.required]]
    })
  }
  nameValidator(control: { value: any; }) {
    const value = control.value;
    if (/[0-9]/.test(value)) {
      return { containsNumber: true };
    }
    return null;
  }
  onLogin()
  {
    if(this.loginForm.valid)
    {
    this.service.login(this.loginForm.value).subscribe((res:any)=>
    {
      const token = res.token; // Assuming the token is returned as 'token'
        this.tokenservice.setUserRoleFromToken(token);
        localStorage.setItem('userId',res.id);
     console.log(res);
     
        
      if (res.token == null) {
        Swal.fire({
          icon: 'error',
          title: 'Invalid User',
          text: 'Please check your credentials and try again.',
        }).then(() => {
          location.reload();
        });
      } else {
        localStorage.setItem('token', res.token);
        Swal.fire({
          icon: 'success',
          title: 'Logged In',
          text: 'You have successfully logged in!',
        }).then(() => {
          this.router.navigate(['/get']);
        });
      }
    });
  }
  }
  onSignup()
  {
    this.router.navigate(['/signup'])
  }
  

}
