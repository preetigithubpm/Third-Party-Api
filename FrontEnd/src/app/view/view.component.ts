import { Component, ElementRef, Inject, ViewChild } from '@angular/core';
import { ServiceService } from '../service.service';
import { MatDialogRef,MAT_DIALOG_DATA } from '@angular/material/dialog';
import html2canvas from 'html2canvas';
import jsPDF from 'jspdf';


@Component({
  selector: 'app-view',
  templateUrl: './view.component.html',
  styleUrls: ['./view.component.css']
})
export class ViewComponent {


  constructor(private service:ServiceService,private _dialogref:MatDialogRef<ViewComponent>,@Inject(MAT_DIALOG_DATA) public data:any){}

 ngOnInit()
 {
  this.service.getById(this.data.patientId).subscribe((res:any)=>
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
