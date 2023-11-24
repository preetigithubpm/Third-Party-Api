import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ServiceService {

  constructor(private http:HttpClient) { }
  cartItems: any[] = [];

  addToCart(product: any) {
    this.cartItems.push(product);
  }

  getCartItems() {
    return this.cartItems;
  }
  getAll()
  {
    return this.http.get('http://localhost:5258/api/PatiientApi/GetAllPatient')
  }
  getAllimag()
  {
    return this.http.get('http://localhost:5258/api/PatiientApiImage/GetAllImage')
  }
  getcartbyid(id:number)
  {
    return this.http.get('http://localhost:5258/api/PatiientApiImage/getcart?id1='+id)
  }
  getCall(data:any)
  {
    const requestBody = JSON.stringify(data);
const number="+917819860668";
let urls='http://localhost:5258/api/Call/callOtp?to='+data;
    // Send the POST request
    // return this.http.post<any>(`${this.apiUrl}/endpoint`, requestBody, { headers });
let datas=this.http.post<any>(`${urls}`, data);
return datas;
    // return this.http.post('http://localhost:25571/api/Call/callOtp?to=%2B'$data)
  }
  getAllImage()
  {
    return this.http.get('http://localhost:5258/api/Image/GetAllImages')
  }
  getAllImagedetails(): Observable<any[]> { // Specify the response type as any[]
    return this.http.get<any[]>('http://localhost:5258/api/Image/GetAllImagesTHroughDeatils');
  }
  
  addPatient(data:any)
  {
    return this.http.post('http://localhost:5258/api/PatiientApi/PostPatient',data)
  }
  sendfax(data:any)
  {
    return this.http.post('http://localhost:5258/api/Documo/SendFaxRes',data)
  }
  addPatientImage(data:any)
  {
    return this.http.post('http://localhost:5258/api/PatiientApiImage/AddPatientImage',data)
  }
  addpay(data:any)
  {
    return this.http.post('http://localhost:5258/api/PatiientApi/addpaydetails',data)
  }
  imGEuPLOAding(data:any)
  {
    return this.http.post('http://localhost:5258/api/Image/Uploading',data)
  }
  sendMail(data:any)
  {
    return this.http.post('http://localhost:5258/api/EmailsEND/SedingMialFrontEnd',data)
  }
  senadText(data:any)
  {
    return this.http.post('http://localhost:5258/api/Sms/SendMessege',data)
  }
  sessioncreation(data:any)
  {
    return this.http.post('http://localhost:5258/api/Session/createSession',data)
  }
  sessionCustomwercreation(data:any)
  {
    return this.http.post('http://localhost:5258/api/Session/createSessionpriceid',data)
  }
  senadPrice(data:any)
  {
    return this.http.post('http://localhost:5258/api/Price/createprice',data)
  }
  sendpaylink(data:any)
  {
    return this.http.post('http://localhost:5258/api/Link/createpaymentlink',data)
  }
  addProd(data:any)
  {
    return this.http.post('http://localhost:5258/api/Product/products',data)
  }
  getById(id:number)
  {
    return this.http.get('http://localhost:5258/api/PatiientApi/GetById?id='+id)
  }
  getstatus(cstestid:any)
  {
    return this.http.get('http://localhost:5258/api/Session/sessionid?sessionid='+cstestid)
  }
  getBywebhook(id:number)
  {
    return this.http.get('http://localhost:5258/api/PayementWehook/paysuccess'+id)
  }
  getByIdimage(id:number)
  {
    return this.http.get('http://localhost:5258/api/PatiientApiImage/GetByIdImage?id='+id)
  }
  updatePatient(data:any)
  {
    return this.http.put('http://localhost:5258/api/PatiientApi/UpdatePatient',data)
  }
  updatePatientimage(data:any)
  {
    return this.http.put('http://localhost:5258/api/PatiientApiImage/UpdatePatientImage',data)
  }
  deletePatient(id:any)
  {
    return this.http.delete('http://localhost:5258/api/PatiientApi/DeletePatient?id='+id);
  }
  deletePatientimage(id:any)
  {
    return this.http.delete('http://localhost:5258/api/PatiientApiImage/DeletePatientImage?id='+id);
  }
  login(data:any)
  {
    return this.http.post('http://localhost:5258/api/LoginApi/LoginApi',data)
  }
  signUp(data:any)
  {
    return this.http.post('http://localhost:5258/api/LoginApi/Register',data)
  }
  getPatientCountData(): Observable<any> {
    return this.http.get('http://localhost:5258/api/PatiientApi/GetAllPatientCount');
  }
  getPatientCountDataDynamic(): Observable<any> {
    return this.http.get('http://localhost:5258/api/PatiientApi/GetAllPatientCountDynamically');
  }
  verifyOtp(otp:string)
  {
    return this.http.post('http://localhost:5258/api/LoginApi/VerifyOtp',otp)
  }
  getProfile(id:any)
  {
    return this.http.get('http://localhost:5258/api/LoginApi/GetByIdProfile?id=',id)
  }
  addToCartItem(data:any){
    return this.http.post('http://localhost:5258/api/PatiientApi/addToCart',data)
  }
}


