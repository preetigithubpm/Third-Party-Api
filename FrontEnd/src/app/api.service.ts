import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  
  constructor(private http:HttpClient) { }
  makePayment(stripeToken: any): Observable<any> {
    // Ensure that you include the "Token" field in the request body
    const requestBody = { TokenId: stripeToken }; 

    const headers = { 'Content-Type': 'application/json' }; // Set the content type to JSON
    return this.http.post<any>('http://localhost:25571/api/Payments/MakePayment', JSON.stringify(requestBody), { headers });
  }


  cartItems: any[] = [];

  addToCart(product: any) {
    this.cartItems.push(product);
  }

  getCartItems() {
    return this.cartItems;
  }
}
