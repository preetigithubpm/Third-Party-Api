import { Injectable } from '@angular/core';
import jwt_decode from 'jwt-decode';

@Injectable({
  providedIn: 'root'
})
export class TokenserviceService {

  constructor() { }
  private userRole!: string;

  setUserRoleFromToken(token: string): void {
    const decodedToken: any = jwt_decode(token);
    this.userRole = decodedToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];
  }

  getUserRole(): string {
    return this.userRole;
  }
}
