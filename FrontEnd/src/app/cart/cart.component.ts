import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ServiceService } from '../service.service';
import { Router } from '@angular/router';
import { DataService } from '../data.service';
import Swal from 'sweetalert2';
import { Pipe, PipeTransform } from '@angular/core';


@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent {
  cartCount = 0;
  quantity:number=1;

  imageUrls: any[] = [];

  check:string=''
  userId:any=0;
  books: any;
  constructor(private ser:ServiceService,private _dialog: MatDialog,private router:Router,private dataservice:DataService) { }
  addToCart(product:any) { 
    this.userId=localStorage.getItem('userId')
    product.userId=this.userId;
    product.quantity=this.quantity; 
    this.ser.addToCartItem(product).subscribe((res:any)=>{
        Swal.fire({
          icon: 'success',
          title: 'Cart',
          text: 'Added to Cart',
        }).then(() => {
      
          });
          
        })

    }
  
    ngOnInit(): void {
      this.fetchImageUrls();
    }
    
    fetchImageUrls() {
      this.ser.getAllImagedetails().subscribe(
        (response: any[]) => {
          this.imageUrls = Object.values(response);
          console.log(this.imageUrls);
        },
        (error) => {
          console.error('Error fetching image URLs:', error);
        }
      );
    }
    
    imageShow(data: any) {
      this.check = 'http://localhost:5258' + data; 
      return this.check;
    }
    addtobag(){
      this.router.navigate(['/bag'])
    }
    applyFilter(filterValue: string) {
      this.imageUrls = this.books.filter((book: { userName: string; }) =>
        book.userName.toLowerCase().includes(filterValue.toLowerCase())
      );
    }
    
}
