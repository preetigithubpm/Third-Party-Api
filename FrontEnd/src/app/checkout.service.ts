import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CheckoutService {

  private apiUrl = 'http://localhost:25571/api/CheckOut/createCheckout';

  constructor(private http: HttpClient) {}

  createCheckoutSession(data:any): Observable<any> {
   

    return this.http.post(this.apiUrl, data);
  }

}
