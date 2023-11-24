import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { AngularEditorConfig } from '@kolkov/angular-editor';
import { ServiceService } from '../service.service';
import Swal from 'sweetalert2';
import { Dialog } from '@angular/cdk/dialog';
import { JsonPipe } from '@angular/common';
import { DataService } from '../data.service';

@Component({
  selector: 'app-editor',
  templateUrl: './editor.component.html',
  styleUrls: ['./editor.component.css']
})
export class EditorComponent {
  selectedFile: File | null = null;

// Modify the onFileSelected function to store the selected file
onFileSelected(event: any) {
  this.selectedFile = event.target.files[0];
}

  data:any
  name = 'Angular 6';
  htmlContent = '';
  value:string=this.htmlContent;
  


  config: AngularEditorConfig = {
    editable: true,
    spellcheck: true,
    height: '15rem',
    minHeight: '5rem',
    placeholder: 'Enter text here...',
    translate: 'no',
    defaultParagraphSeparator: 'p',
    defaultFontName: 'Arial',
    toolbarHiddenButtons: [
      ['bold']
      ],
    customClasses: [
      {
        name: "quote",
        class: "quote",
      },
      {
        name: 'redText',
        class: 'redText'
      },
      {
        name: "titleText",
        class: "titleText",
        tag: "h1",
      },
    ]
  };
 
  constructor(private ser: ServiceService,private dialogdata: Dialog,private down:DataService) {} 

  sendFax() {
    const formData = new FormData();

    // Add the HTML content to the FormData
    formData.append('htmlContent', this.htmlContent);
  
    // Add the selected file to the FormData
    
    console.log(this.htmlContent);
    let payload={
      value:(this.htmlContent).toString()
    }
   this.ser.sendfax(payload).subscribe((res:any)=>{
    console.log(res)
    if (res != null) {
      Swal.fire({
        icon: 'success',
        title: ' ',
        text: 'fax send Sucessfully',
      }).then(() => {
        this.dialogdata.closeAll();
      });
    }
    else {
      Swal.fire({
        icon: 'error',
        title: 'Invalid User',
        text: 'Please check your credentials and try again.',
      }).then(() => {
        location.reload();
      });

    }
   })
  }
  download(datadown:any){
    console.log(datadown);
      this.down.generatePdf(datadown);
  }
}
