import { HttpClient } from '@angular/common/http';
import { Component, ElementRef, ViewChild } from '@angular/core';
import { ServiceService } from '../service.service';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { PaymentComponent } from '../payment/payment.component';

@Component({
  selector: 'app-camera-upload',
  templateUrl: './camera-upload.component.html',
  styleUrls: ['./camera-upload.component.css']
})
export class CameraUploadComponent {
  imageUrls: any[] = [];

  check:string=''
  
    constructor(private ser:ServiceService,private _dialog: MatDialog) { }
  
    ngOnInit(): void {
      this.fetchImageUrls();
    }
    
    fetchImageUrls() {
      this.ser.getAllImagedetails().subscribe(
        (response: any[]) => {
          this.imageUrls = Object.values(response);

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
    openpay() {
      const dialogConfig = new MatDialogConfig();
      dialogConfig.width = '75%'; // Set the width as a percentage of the screen
      dialogConfig.height = '75%'; // Set the height as a percentage of the screen
      dialogConfig.position = { top: '5%', left: '5%' }; // Center the dialog on the screen
      
      const dialogRef = this._dialog.open(PaymentComponent, dialogConfig);
      
      dialogRef.afterClosed().subscribe(res => {

      });
    }
}
