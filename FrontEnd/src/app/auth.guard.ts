import { Injectable } from '@angular/core';
import { CanActivate, CanActivateFn, Router } from '@angular/router';
import { ServiceService } from './service.service';

@Injectable({
  providedIn: 'root',
})
export class AuthGuard implements CanActivate {
  constructor(private authService: ServiceService, private router: Router) {}

  canActivate(): boolean {
    
    if (localStorage.getItem("token")!=null) {
      return true; 
    }
    this.router.navigate([''])
    return false; 
  }
}
