import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  private apiBaseUrl = 'http://localhost:5258/api/PatiientApiImage';

  constructor(private http: HttpClient) {}

  getCartItems(userId: number): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiBaseUrl}/getcart?id1=${userId}`);
  }
}
