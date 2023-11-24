import { Component, Inject } from '@angular/core';
import jsPDF from 'jspdf';
import { ServiceService } from '../service.service';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import html2canvas from 'html2canvas';

@Component({
  selector: 'app-getbyidiamge',
  templateUrl: './getbyidiamge.component.html',
  styleUrls: ['./getbyidiamge.component.css']
})
export class GetbyidiamgeComponent {
  check: any;
  constructor(private service:ServiceService,private _dialogref:MatDialogRef<GetbyidiamgeComponent>,@Inject(MAT_DIALOG_DATA) public data:any){}

  ngOnInit()
  {
   this.service.getByIdimage(this.data.patientId).subscribe((res:any)=>
   {
     this.data=res
     console.log(this.data);
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
 imageShow(data1: any) {
  this.check = 'http://localhost:5258' + data1; 
  return this.check;
}
}
