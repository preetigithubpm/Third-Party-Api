import { Component, Inject, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Patient } from '../patients';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MAT_DIALOG_DATA, MatDialog, MatDialogConfig, MatDialogRef } from '@angular/material/dialog';
import { ServiceService } from '../service.service';
import { Router } from '@angular/router';
import { TokenserviceService } from '../tokenservice.service';
import { DownloadService } from '../download.service';
import { AddImageComponent } from '../add-image/add-image.component';
import { ChartComponent } from '../chart/chart.component';
import Swal from 'sweetalert2';
import { AddeditComponent } from '../addedit/addedit.component';
import { environment } from '../Environment/environment';
import { ImageUploadComponent } from '../image-upload/image-upload.component';
import { GetbyidiamgeComponent } from '../getbyidiamge/getbyidiamge.component';
import { CameraUploadComponent } from '../camera-upload/camera-upload.component';
import { ImageGridComponent } from '../image-grid/image-grid.component';
import jsPDF from 'jspdf';
import html2canvas from 'html2canvas';

@Component({
  selector: 'app-getesssion',
  templateUrl: './getesssion.component.html',
  styleUrls: ['./getesssion.component.css']
})
export class GetesssionComponent {
  constructor(private service:ServiceService,private _dialogref:MatDialogRef<GetesssionComponent>,@Inject(MAT_DIALOG_DATA) public data:any){}

  ngOnInit()
  {
   this.service.getBywebhook(this.data).subscribe((res:any)=>
   {
     this.data=res
     console.log("this.data",this.data);
     console.log("this.data.id",this.data.id);
   })
  }
  generatePDF() {
   if (!this.data) {
     // Data not loaded yet, prevent PDF generation
     return;
   }
 
   const pdf = new jsPDF('p', 'mm', 'a4');
   const content = document.getElementById('pdf-content');
 
   if (content) {
     html2canvas(content).then((canvas) => {
       const imgData = canvas.toDataURL('image/png');
       pdf.addImage(imgData, 'PNG', 10, 10, 190, 0);
       pdf.save('generated_pdf.pdf');
     });
   } else {
     console.error("Element with ID 'pdf-content' not found.");
   }
 }
 
 
 
 
 onNoClick(): void {
   this._dialogref.close();
 }
 
}
