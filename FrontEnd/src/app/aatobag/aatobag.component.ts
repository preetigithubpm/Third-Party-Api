import { Component, Input, OnInit } from '@angular/core';
import { ApiService } from '../api.service';
import { DataService } from '../data.service';
import { CartService } from '../cart.service';
import { Router } from '@angular/router';
import { environment } from '../Environment/environment';
import { ServiceService } from '../service.service';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { PaymentComponent } from '../payment/payment.component';

@Component({
  selector: 'app-aatobag',
  templateUrl: './aatobag.component.html',
  styleUrls: ['./aatobag.component.css']
})
export class AatobagComponent implements OnInit{
  cartItems: any[] = [];
  check:any
  isImage:boolean=false
gRANDTOTAL!:number
  gentotal!:number;

  constructor(private cartService: CartService,private roter:Router,private ser:ServiceService,private _dialog: MatDialog) {}
 

  ngOnInit(): void {
    // Fetch cart items when the component initializes
    this.loadCartItems();
  }

  loadCartItems() {
    const userId = 15; // Replace with the appropriate user ID
    this.cartService.getCartItems(userId).subscribe((items:any) => {
      this.cartItems = items;
    });
  }
  back(){
      this.roter.navigate(['/get'])
  }
  openImg(imagePath:any) {
  
    this.check=environment.apiUrl+imagePath;
   
    
    return this.check;
  }
  openImg1(imagePath:any){
    this.isImage=true;
    this.check=environment.apiUrl+imagePath;
    return this.check;
  }
  increasing(data:any){
     data.quantity++;
     data.totalPrice=(data.price)*(data.quantity)
   
    
  }
  decreasing(data:any){
     data.quantity--;
     data.totalPrice=(data.price)*(data.quantity)
   
  }
  get totalCartPrice(): number {
    return this.cartItems.reduce((total, item) => total + (item.quantity * item.price), 0);
  }
  updatecart(val:any){
     this.ser.addToCartItem(val).subscribe((res:any)=>{
         this.loadCartItems();
     })
  }
  ordernow(){
    const dialogConfig = new MatDialogConfig();
      dialogConfig.width = '75%'; // Set the width as a percentage of the screen
      dialogConfig.height = '75%'; // Set the height as a percentage of the screen
      dialogConfig.position = { top: '5%', left: '5%' }; // Center the dialog on the screen
      
      const dialogRef = this._dialog.open(PaymentComponent, dialogConfig);
      
      dialogRef.afterClosed().subscribe(res => {

      });
    }
    placedtotalamount(data:any){
          
    }
    placeOrder(){
      const dialogConfig = new MatDialogConfig();
      dialogConfig.width = '75%'; // Set the width as a percentage of the screen
      dialogConfig.height = '75%'; // Set the height as a percentage of the screen
      dialogConfig.position = { top: '5%', left: '5%' }; // Center the dialog on the screen
      
      const dialogRef = this._dialog.open(PaymentComponent, dialogConfig);
      
      dialogRef.afterClosed().subscribe(res => {

      });
    }
  
  }

