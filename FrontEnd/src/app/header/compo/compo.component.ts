import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import html2canvas from 'html2canvas';
import jsPDF from 'jspdf';
import { ServiceService } from 'src/app/service.service';
import { ViewComponent } from 'src/app/view/view.component';

@Component({
  selector: 'app-compo',
  templateUrl: './compo.component.html',
  styleUrls: ['./compo.component.css']
})
export class CompoComponent {
  constructor(private service:ServiceService,private _dialogref:MatDialogRef<CompoComponent>,@Inject(MAT_DIALOG_DATA) public data:any){}

  ngOnInit()
  {
    console.log(this.data.id);
    
   this.service.getProfile(this.data.id).subscribe((res:any)=>
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
 
}
