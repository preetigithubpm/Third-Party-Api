import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ServiceService } from '../service.service';

@Component({
  selector: 'app-image-grid',
  templateUrl: './image-grid.component.html',
  styleUrls: ['./image-grid.component.css']
})
export class ImageGridComponent implements OnInit {
  imageUrls: any[] = [];

check:string=''
  constructor(private http: HttpClient,private ser:ServiceService) { }

  ngOnInit(): void {
    this.fetchImageUrls();
  }
  
  fetchImageUrls() {
    this.ser.getAllImage().subscribe(
      (response:any) => {
        this.imageUrls=response

        
      },
      (error) => {
        console.error('Error fetching image URLs:', error);
      }
    );
  }
  imageShow(data: any) {
    this.check = 'http://localhost:5258/' + data; 
    console.log("im",this.imageUrls);
    console.log("c",this.check);
    
    return this.check;
  }
}
